var listaRespostas = [], idResposta = 0;

// Validação do formulário de criação de perguntas
$(document).ready(function () {
    var $perguntaAddForm = $("#frmPerguntaAdd");

    jQuery.validator.addMethod("noSpace", function (value, element) {
        return value = '' || value.trim().length != 0
    }, "Espaços apenas não são permitidos");


    if ($perguntaAddForm.length) {
        $perguntaAddForm.validate({
            rules: {
                perguntaDesc: {
                    required: true,
                    noSpace: true,
                    maxlength: 100
                },
                pontos: {
                    required: true,
                    min: 1,
                    max: 20
                },
                respostaSelect: {
                    required: true
                },
                respostaTexto1: {
                    required: true,
                    noSpace: true,
                    maxlength: 100
                },
                respostaTexto2: {
                    required: true,
                    noSpace: true,
                    maxlength: 100
                },
                respostaTexto3: {
                    required: true,
                    noSpace: true,
                    maxlength: 100
                },
                respostaTexto4: {
                    required: true,
                    noSpace: true,
                    maxlength: 100
                },
                respostaTexto5: {
                    required: true,
                    noSpace: true,
                    maxlength: 100
                }
            },
            messages: {
                respostaSelect: {
                    required: 'Selecione a resposta correta!'
                }
            },
            errorPlacement: function (erro, elemento) {
                if (elemento.is(":radio")) {
                    erro.appendTo(elemento.parents(".respostas"));
                } else if (elemento.is("input[type=text]")) {
                    erro.appendTo(elemento.parents(".form-row"));
                }
                //else {
                //    erro.insertAfter(elemento);
                //}
            },
            submitHandler: function (form) {
                addPergunta();
            }
        });
    };
});

// Ler respostas antes de salvar a pergunta
function addPergunta() {

    $('#AreaResposta .form-row').each(function () {

        var verifica = false;
        if ($(this).find("input[type=radio]").is(":checked")) {
            verifica = true;
        }
        var linha = {
            //perguntaId: $("#perguntaDesc").val(),
            perguntaId: $("#perguntaId").val(),

            descricao: $(this).find("input[type=text]").val(),
            respostaCerta: verifica
        }

        listaRespostas.push(linha);
    });

    enviarDados(listaRespostas);
}

// Enviar pergunta com respostas para a base de dados
function enviarDados(itens) {

    var pergunta = {
        questionarioId: $("#questionarioId").val(),
        perguntaId: $("#perguntaId").val(),
        descricao: $("#perguntaDesc").val(),
        pontos: $("#pontos").val()
    }

    $.post("/QuestionarioAdmin/AddPergunta/", { 'pergunta': pergunta, 'respostas': listaRespostas }, function (data) {
        if (data != null) {

            $("#totalPerguntas").attr("data-conta", data.totalPerguntas);
            $("#totalPerguntas").html("Perguntas Total - " + data.totalPerguntas);

            var htmlPerguntaAdd = "";
            let conta = 0;
            data.perguntas.forEach(function (entidade) {
                conta++;

                htmlPerguntaAdd += "<div class='form-group col' id='grupoPergunta_" + entidade.PerguntaId + "'>";
                htmlPerguntaAdd += "<label class='col-form-label mr-2'>" + conta + " - " + entidade.Descricao + "</label>";
                htmlPerguntaAdd += "<label class='col-form-label font-weight-bold mr-2'>Pontos - " + entidade.Pontos + "</label>";
                htmlPerguntaAdd += "<label class='col-form-label font-weight-bold'>Respostas - " + entidade.TotalRespostas + "</label>";
                htmlPerguntaAdd += "<button type='button' onclick='atualizarPergunta(" + entidade.PerguntaId + ")' class='btn btn-sm btn-success text-white rounded ml-1 mr-1'><i class='fa fa-edit'></i> </button>";

                htmlPerguntaAdd += "<button type='button' onclick=$('#eliminarId').attr('data-eliminarId'," + entidade.PerguntaId + "); data-toggle='modal' data-target='#eliminarDadosModal' class='btn btn-sm btn-danger rounded'><i class='fa fa-trash-alt'></i></button>";
                htmlPerguntaAdd += " </div>";
            });

            $("#AreaPergunta .form-group").remove();
            $("#AreaPergunta").append(htmlPerguntaAdd);

            listaRespostas = [];
            $("#addEditPerguntaModal").modal('hide');

            alert("Sucesso");
        }
    });
}

// Adicionar resposta na lista/Formulário
function addResposta() {
    var contaMax = parseInt($("#contaRespostas").attr("max"));

    if (idResposta < contaMax) {

        idResposta++;

        $("#AreaResposta").append(
            "<div class='form-row col-md-12 mb-3' id='grupoResposta" + idResposta + "' >" +
            " <div class='input-group col-md-12'>" +
            "  <input type='text' name='respostaTexto" + idResposta + "' required class='form-control border border-primary'>" +
            " <div class='input-group-prepend'>" +
            " <div class='input-group-text border border-info badge-info'>" +
            " <input id='resposta" + idResposta + "' type='radio' name='respostaSelect'>" +
            "<label for='resposta" + idResposta + "' class='form-check-label ml-1'>Resposta Correta</label>" +
            " </div>" +
            " <button onclick='removerResposta(" + idResposta + ");' type='button' class='btn btn-danger rounded-right'>&times;</button>" +
            "</div>" +
            " </div>" +
            "</div>"
        );

        $("#contaRespostas").val(idResposta);
    }

    if (idResposta == contaMax) {
        $("#btnNovaResposta").attr("hidden", true);
    }
}

// Remover resposta da lista/Formulário
function removerResposta(respostaId) {
    var contaMin = parseInt($("#contaRespostas").attr("min"));

    if (idResposta > contaMin) {
        $("#AreaResposta").find("div#grupoResposta" + respostaId).remove();

        idResposta--;
        $("#contaRespostas").val(idResposta);

        $("#btnNovaResposta").attr("hidden", false);
    }
}

// Com a Modal
function atualizarPergunta(perguntaId) {
    $('#frmPerguntaAdd')[0].reset();
    $('#addEditPerguntaModalTitle').html("Editar Pergunta");
    $('#perguntaId').val(0);

    idResposta = 0;
    $("#AreaResposta .form-row").remove();
    $("#contaRespostas").val($("#contaRespostas").attr("min"));

    $.ajax({
        type: 'GET',
        url: "/QuestionarioAdmin/BuscaPerguntaPorId?id=" + perguntaId,
        dataType: 'JSON',
        cache: false,
        success: function (data) {

            var obj = JSON.parse(data.pergunta);
            $('#perguntaId').val(obj.Id);
            $("#perguntaDesc").val(obj.Descricao);
            $("#pontos").val(obj.Pontos);
            $("#contaRespostas").val(data.totalRespostas);

            if (data.totalRespostas > 0) {

                var htmlConteudo = "";
                data.respostas.forEach(function (entidade) {

                    idResposta++;

                    var verifica = "";
                    if (entidade.RespostaCerta) {
                        verifica = "checked";
                    }

                    htmlConteudo += "<div class='form-row col-md-12 mb-3' id='grupoResposta" + idResposta + "' >";
                    htmlConteudo += "<div class='input-group col-md-12'>";
                    htmlConteudo += "<input type='text' name='respostaTexto" + idResposta + "' value='" + entidade.Descricao + "' required class='form-control border border-primary'>";
                    htmlConteudo += "<div class='input-group-prepend'>";
                    htmlConteudo += "<div class='input-group-text border border-info badge-info'>";
                    htmlConteudo += "<input id='resposta" + idResposta + "' type='radio' " + verifica + " name='respostaSelect'>";
                    htmlConteudo += "<label for='resposta" + idResposta + "' class='form-check-label ml-1'>Resposta Correta</label>";
                    htmlConteudo += "</div>";
                    htmlConteudo += "<button onclick='removerResposta(" + idResposta + ");' type='button' class='btn btn-danger rounded-right'>&times;</button>";
                    htmlConteudo += "</div>";
                    htmlConteudo += "</div>";
                    htmlConteudo += "";

                    htmlConteudo += "</div>";
                });

                $("#AreaResposta").append(htmlConteudo);
            }
            else {
                $("#contaRespostas").val($("#contaRespostas").attr("min"));
                var contaRespostas = $("#contaRespostas").attr("value");

                for (var i = 0; i < contaRespostas; i++) {
                    addResposta();
                }
            }

            $("#contaRespostas").val(idResposta);

            $("#addEditPerguntaModal").modal();
        },
        error: function (result) {
            alert("Erro, tente mais tarde!");
        }
    });
}

// Carregar Modal Vazia
function novaPergunta() {
    $('#frmPerguntaAdd')[0].reset();
    $('#addEditPerguntaModalTitle').html("Add Nova Pergunta");
    $('#perguntaId').val(0);

    idResposta = 0;
    $("#AreaResposta .form-row").remove();
    $("#contaRespostas").val($("#contaRespostas").attr("min"));
    var contaRespostas = $("#contaRespostas").attr("value");

    for (var i = 0; i < contaRespostas; i++) {
        addResposta();
    }

    $("#addEditPerguntaModal").modal();
}



// Eliminar pergunta na base de dados
function eliminarPergunta(perguntaId) {

    if (perguntaId != null) {
        $.ajax({
            type: "POST",
            dataType: 'JSON',
            data: { "id": parseInt(perguntaId) },
            url: "/QuestionarioAdmin/EliminarPergunta/",
            success: function (data) {
                if (data.sucesso) {
                    alert('Eliminado com sucesso ' + perguntaId);
                    window.location.href = "/QuestionarioAdmin/Create/" + $("#questionarioId").val();
                }
            },
            error: function (result) {
                alert("Erro, tente mais tarde!");
            }
        })
    }
}
