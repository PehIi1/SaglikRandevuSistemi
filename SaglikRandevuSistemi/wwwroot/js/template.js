document.querySelectorAll(".div1").forEach(div => {debugger
    div.addEventListener("click", function () {
        document.querySelectorAll(".div1").forEach(d => d.classList.add("hidden"));
        document.querySelectorAll(".div2").forEach(d => d.classList.remove("hidden"));
    });
});

document.querySelectorAll(".div2").forEach(button => {
    button.addEventListener("click", function () {
        document.querySelectorAll(".div2").forEach(d => d.classList.add("hidden"));
        document.querySelectorAll(".div1").forEach(d => d.classList.remove("hidden"));
    });
});