﻿
function detectDeviceType() {
    const userAgent = navigator.userAgent.toLowerCase();
    if (/mobile|android|iphone|ipad|phone/i.test(userAgent)) {
        return "mobile";
    } else if (/tablet|ipad/i.test(userAgent)) {
        return "tablet";
    } else {
        return "desktop";
    }
}

// Função para exibir a mensagem com base no tipo de dispositivo
//function showMessage() {
  //  const deviceType = detectDeviceType();
    //const messageContainer = document.getElementById("messageContainer");

//    if (deviceType === "desktop") {
  //      messageContainer.innerHTML = "<div>Olá, estou no PC!</div>";
    //} else if (deviceType === "mobile") {
     //   messageContainer.innerHTML = "<div>Olá, estou no celular!</div>";
    //} else {
     //   messageContainer.innerHTML = "<div>Olá, estou no tablet!</div>";
 //   }
//}

// Chamamos a função showMessage() para exibir a mensagem assim que a página for carregada
//showMessage();

//id="messageContainer" adicione esse id no html quando precisar usar essa função

$('.btn-close').click(function () {
    $('.alert').hide('hide');
});