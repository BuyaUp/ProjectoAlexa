var listaProvas = [];
$("#resultadoExame").text("Infelizmente não respondeu nenhuma questão. A sua pontuação é '0'!");
function terminarExame() {
    stop();
    //Verificar cada radio button
    $("input:radio").each(function (index) {
        //Verificar apenas as radios marcadas
        if ($(this).prop("checked")) {
            //alert(index + ": IdResposta= " + $(this).attr("idResposta") + " : IdPergunta= " + $(this).attr("idPergunta") + " resposta: " + $(this).attr("texto"));


            //Adicionar respostas na lista de respostas
            var prova = {
                PerguntaId: $(this).attr("idPergunta"),
                RespostaSelecionadaId: $(this).attr("idResposta"),
                ExameId: $(this).attr("idExame")
            };

            listaProvas.push(prova);
        }
    });

    enviarDados(listaProvas);

}

//Enviar os dados na base de dados
function enviarDados(provas) {

    var totalPontos = parseInt($("#totalPontos").text());


    $.post("https://localhost:44329/Exame/AddResposta/", { 'provas': provas, 'totalPontos':totalPontos}, function (data) {

        var resultado = "";

        if (data.resultado) {
            resultado = "aprovado";
        }

        if (!data.resultado) {
            resultado = "reprovado";
        }


        $("#resultadoExame").text("Exame concluído com sucesso! Você foi " + resultado + " com o total de " + data.pontos + "/" + totalPontos + " pontos. O que corresponde a " + parseInt(data.porcentagem) + "% de acerto!");
    })

    abrirModal();
   

}


function fecharModal() {
    window.location.href = "https://localhost:44329/Usuario/Perfil";
}


function abrirModal() {
    $("#myModal").modal({
        show: true
    });
}

