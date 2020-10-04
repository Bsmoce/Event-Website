function checkForm(form) {
    if (form.username.value == "") {
        alert("Error: Username cannot be blank!");
        form.username.focus();
        return false;
    }
    if (form.pwd1.value != form.pwd2.value) {
        alert("Error: Your password and confirmation password do not match!");
        form.pwd1.focus();
        return false;
    }
}