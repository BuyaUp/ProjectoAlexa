
var hora = 1;
var minuto = 0;
var segundo = 0;

var tempo = 1000; // Quantos milésimos valem 1 segundo?(1000).

var cron;

function start() {
    cron = setInterval(timer, tempo);
}

function pause() {
    clearInterval(cron);
}

function stop() {
    clearInterval(cron);
    //$("#contador").text(hora + ":" + minuto + ":" + segundo);
}

function timer() {

    segundo--;

    if (segundo <=0) {
        segundo = 60;
        minuto--;

        if (minuto <=0) {
            minuto = 60;
            hora--;
        }
    }

    if (hora < 0) {

        stop();
        terminarExame()

    }

    var format = (hora < 10 ? '0' + hora : hora) + ':' + (minuto < 10 ? '0' + minuto : minuto) + ':' + (segundo < 10 ? '0' + segundo : segundo);

    $("#contador").text(format);


}


start();



