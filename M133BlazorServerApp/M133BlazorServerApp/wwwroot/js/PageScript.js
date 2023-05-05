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


$(document).ready(function () {
    var click = true;
    $("body").on("click", ".championBox", function () {
        if ($(this).hasClass("clickableFront")) {
            var id = $(this).data("champid");
            flipAnim(id);
            click = true;
        }
    });
    $("body").on("mouseover", ".championBox", function () {
        if ($(this).hasClass("frontAnim")) {
            $(this).removeClass("frontAnim");
            var id = $(this).data("champid");
            var el = document.getElementById(id);
            $(el).css("animation-play-state", "paused");
            $(el).find(".front").css("transform", "scale(1.08)");
            click = false;
        }

    });

    $("body").on("mouseleave", ".championBox", function () {
        if (!click) {
            if ($(this).hasClass("clickableFront")) {
                if (!$(this).find(".back").hasClass("backIsActive")) {
                    $(this).addClass("frontAnim");
                    var id = $(this).data("champid");
                    var el = document.getElementById(id);
                    $(el).css("animation-play-state", "running");
                    $(el).find(".front").css("transform", "scale(1)");
                }
            }
        }
    });

});

function flipAnim(id) {
    var el = document.getElementById(id);

    $(el).css("-webkit-transform", "rotateY(180deg)");
    $(el).css("-moz-transform", "rotateY(180deg)");
    $(el).css("-o-transform", "rotateY(180deg)");
    $(el).css("transform", "rotateY(180deg)");
    $(el).find(".front").css("opacity", "0");
    $(el).find(".back").addClass("backIsActive");
}

function flipClickable(id) {
    var el = document.getElementById(id);
    if (!$(el).find(".back").hasClass("backIsActive")) {

        $(el).addClass("frontAnim");
        $(el).addClass("clickableFront");
    }


}

function flipAll() {
    $(".championBox").css("-webkit-transform", "rotateY(0deg)");
    $(".championBox").css("-moz-transform", "rotateY(0deg)");
    $(".championBox").css("-o-transform", "rotateY(0deg)");
    $(".championBox").css("transform", "rotateY(0deg)");
    $(".championBox").find(".front").css("opacity", "1");
    $(".championBox").find(".back").removeClass("backIsActive");
    $(".championBox").removeClass("clickableFront");
    $(".championBox").removeClass("frontAnim");
    $(".championBox").css("animation-play-state", "running");



}
