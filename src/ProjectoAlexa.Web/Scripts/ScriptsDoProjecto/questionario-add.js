var listaPerguntas, listaRespostas = [];
var idResposta = 1;


function addPergunta() {
    $("#AreaPergunta").append("<div class='row'><div class='col-md-7'> <b>1 - Qual a capital de Angola?</b></div><div class='col-md-3'><button class='btn btn-danger btn-sm' style='margin-left:200px;'>&times;</button></div><div class='ml-4 col-md-10'><div class='row'><input class='form-control col-8' type='text' value='Luanda' /> <input class='form-control col-2' type='checkbox' /></div></div><div class='col-md-12'><hr /></div></div >");

    $('#AreaResposta .form-row').each(function () {

        var verifica = false;
        if ($(this).find("input[type=radio]").is(":checked")) {
            verifica = true;
        }
        var linha = {
            perguntaId: $("#pergunta").val(),

            descricao: $(this).find("input[type=text]").val(),
            respostaCerta: verifica
            //correta: $(this).find("input[type=radio]:checked").val()
        }

        listaRespostas.push(linha);
    });

    enviarDados(listaRespostas);
}

// Enviar para a base de dados
function enviarDados(itens) {
    var carrinho = JSON.stringify(itens);

    var pergunta = {
        questionarioId: $("#questionarioId").val(),
        descricao: $("#pergunta").val(),
        pontos: $("#questionarioId").val()
    }

    $.post("/QuestionarioAdmin/AddPergunta/", { 'pergunta': pergunta, 'respostas': listaRespostas }, function (estado) {
        if (estado != null) {

            //$("#totalPreco").html(estado[1] + " Kz");
            //$("#totalItens").html("" + estado[2]);

            //$('#btn-verProdutos').click();

            //alertify.success('Actualizado!');

        }
    })
}


function addResposta() {

    $("#AreaResposta").append(
        "<div class='form-row col-md-12' id='grupoResposta" + idResposta +"' >"+
           " <div class='input-group col mb-3'>"+
              "  <input type='text' class='form-control border border-primary'>"+
                  " <div class='input-group-prepend'>"+
                       " <div class='input-group-text border border-info badge-info'>"+
                            " <input id='resposta" + idResposta +"' type='radio' name='respostaSelect'>"+
                            "<label for='resposta" + idResposta +"' class='form-check-label ml-1'>Resposta Correta</label>"+
                         " </div>"+
                        " <button onclick='removerResposta(" + idResposta + ");' type='button' class='btn btn-danger rounded-right'>&times;</button>"+
                  "</div>"+
           " </div>"+
        "</div>"
    );

    idResposta++;

}

function removerResposta(resposta) {
    debugger
    $("#AreaResposta").find("div#grupoResposta" + resposta).remove();
    //var Posicao = $("#AreaResposta").find("#" + resposta).remove();
    //Posicao.remove();
}

addResposta();
addResposta();


//function registrarResposta() {

//    var descricao = $('#resposta1').val();
//    var resposta = { Descricao: descricao }

//    $.ajax({
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        data: "{resposta:" + JSON.stringify(resposta) + "}",
//        url: "/QuestionarioAdmin/AddResposta/",
//        success: function (data) {
//            alert("Descrição da resposta: " + data)
//        },
//        error: function (result) {
//            alert("Erro ao salvar a resposta!");
//        }
//    })
//}

