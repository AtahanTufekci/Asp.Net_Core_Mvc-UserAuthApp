(() => {
    const password = document.getElementById("password");
    const showBtn = document.getElementById("show-pass");

    const showHidePassword = () => {
        if (password.type == "password") {
            password.type = "text";
            showBtn.classList.add("fa-eye-slash");
        } else {
            password.type = "password";
            showBtn.classList.remove("fa-eye-slash");
        }
    };
    showBtn.addEventListener("click", showHidePassword);

})();