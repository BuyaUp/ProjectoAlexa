var listaProvas = [];

function terminarExame() {
    //Verificar cada radio button
    $("input:radio").each(function (index) {
        //Verificar apenas as radios marcadas
        if ($(this).prop("checked")) {
            alert(index + ": IdResposta= " + $(this).attr("idResposta") + " : IdPergunta= " + $(this).attr("idPergunta") + " resposta: " + $(this).attr("texto"));


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
    $.post("https://localhost:44329/Exame/AddResposta/", { 'provas': provas }, function (data) {
        alert("Exame concluído com sucesso! Você foi"+data.resultado+ "Com o total de " + data.pontos+" pontos em "+ data.totalDePontos+ ". O que corresponde a "+percentagem+"% de acerto!");
    })
    window.location.href = "https://localhost:44329/Usuario/Perfil";
}





