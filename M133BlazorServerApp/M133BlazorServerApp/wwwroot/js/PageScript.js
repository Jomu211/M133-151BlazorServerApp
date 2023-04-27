function getImage(id) {
    img = document.getElementById(id);
    imgData = getBase64Image(img);
    sessionStorage.setItem("imgData", imgData);
}


function getBase64Image(img) {
    var canvas = document.createElement("canvas");
    canvas.width = 1400;
    canvas.height = 700;

    var ctx = canvas.getContext("2d");
    ctx.drawImage(img, 0, 0);

    var dataURL = canvas.toDataURL("image/png");

    return dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
}

function setImage() {
    var dataImage = sessionStorage.getItem("imgData");
    img = document.getElementById('replaceImage');
    img.src = "data:image/png;base64," + dataImage;
}

function initializeCarousel() {
    $('#carousel').carousel({ interval: 2000 });
    $('#carousel-prev').click(
        () => $('#carousel').carousel('prev'));
    $('#carousel-next').click(
        () => $('#carousel').carousel('next'));

}
function handleInvalid() {
    user = document.getElementById("usernameLoginInput");
    if (!$(user).val()) {
        $(user).css("border-color", "#Ff2f2f");
    } else {
        $(user).css("border-color", "transparent");
    }
    pass = document.getElementById("passwordLoginInput");
    if (!$(pass).val()) {
        $(pass).css("border-color", "#Ff2f2f");
    }
    else {
        $(pass).css("border-color", "transparent");
    }
}
function wrongLogin(invalid) {
    var el = document.getElementsByClassName("wrongLogin");

    if (invalid == true) {
        wrongLogin = document.getElementsByClassName("wrongLogin");
        $(wrongLogin).css("display", "none");
    }
    else {
        if ($(el).css("display", "none")) {
            wrongLogin = document.getElementsByClassName("wrongLogin");
            $(wrongLogin).css("display", "inline");
        } else {
            wrongLogin = document.getElementsByClassName("wrongLogin");
            $(wrongLogin).css("display", "none");
        }
    }
}


function flipImage(id) {
    var el = document.getElementById(id);
    $(el).css("-webkit-transform","rotateY(180deg)");
    $(el).css("-moz-transform","rotateY(180deg)");
    $(el).css("-o-transform","rotateY(180deg)");
    $(el).css("transform", "rotateY(180deg)");
    $(el).find(".front").css("opacity", "0"); 
    $(el).find(".back").addClass("backIsActive");
}