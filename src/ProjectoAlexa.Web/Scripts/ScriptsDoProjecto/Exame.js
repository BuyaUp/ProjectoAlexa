var listaResposta = [];

function terminarExame() {
    //Verificar cada radio button
    $("input:radio").each(function (index) {
        //Verificar apenas as radios marcadas
        if ($(this).prop("checked")) {
            alert(index + ": IdResposta= " + $(this).attr("idResposta") + " : IdPergunta= " + $(this).attr("idPergunta") + " resposta: " + $(this).attr("texto"));


            //Adicionar respostas na lista de respostas
            var resposta = {
                PerguntaId =$(this).attr("idPergunta"),
                RespostaId =$(this).attr("idResposta")
            }

            //Enviar os dados e cadastrar na tabela prova

        }
    });

}





