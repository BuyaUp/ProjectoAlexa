
var hora = 0;
var minuto = 0;
var segundo = 0;

var tempo = 1000; // Quantos milésimos valem 1 segundo.

var cron;

function start() {
    cron = setInterval(timer, tempo);
}

function pause() {
    clearInterval(cron);
}

function stop() {
    clearInterval(cron);
    //hora = 0;
    //minuto = 0;
    //segundo = 0;

    $("#contador").text() = hora + ":" + minuto + ":" + segundo;
 }

function timer() {

    segundo++;

    if (segundo == 60) {
        segundo = 0;
        minuto++;

        if (minuto == 60) {
            minuto = 0;
            hora++;
        }
    }



    var format = (hora < 10 ? '0' + hora : hora) + ':' + (minuto < 10 ? '0' + minuto : minuto) + ':'+(segundo < 10 ? '0' + segundo : segundo);

    $("#contador").text(format);
}


start();



