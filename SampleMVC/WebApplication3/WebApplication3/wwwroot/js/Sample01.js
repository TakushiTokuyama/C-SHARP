var find = document.getElementById("find");
var result = document.getElementById("result");
var p = result.getElementsByTagName("p");

// 初期表示
window.onload = function onLoad() {
    show();
    console.log("onLoad")
}

function show() {
    if (p[0].textContent != "") {
        result.style.display = "block";
        console.log("block");
    } else {
        result.style.display = "none";
        console.log("none");
    }
}

function clear() {
    p[0].textContent = "";
    show();
    console.log("clear");
}