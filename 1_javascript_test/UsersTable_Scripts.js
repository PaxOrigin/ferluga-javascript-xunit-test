class User {
    name;
    secondName;
    email;
    constructor(name, secondName, email) {
        this.name = name;
        this.secondName = secondName;
        this.email = email;
    }
}

const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
const validEmail = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
var users = [];


const onSubmit = () => {
    let name = document.getElementById("name-input");
    let secondName = document.getElementById("second-name-input");
    let email = document.getElementById("email-input");
    users.push(new User(name.value, secondName.value, email.value));
    updateTable();
    clearField();

}

const deleteUser = (index) => {
    console.log("Premuto");
    users.splice(index, 1);
    updateTable();
}

const editUser = (index) => {
    console.log(index);
    let title = document.getElementById("form-fields-text");
    title.textContent = "Edit a User";
    let name = document.getElementById("name-input");
    let secondName = document.getElementById("second-name-input");
    let email = document.getElementById("email-input");
    let userToEdit = users[index];
    console.log(userToEdit.email);
    name.value = userToEdit.name;
    secondName.value = userToEdit.secondName;
    email.value = userToEdit.email;

}


function searchTable() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("searchText");
    filter = input.value.toUpperCase();
    table = document.getElementById("table-body");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {

        td = tr[i].getElementsByTagName("td")[3];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

const updateTable = () => {
    let table = document.getElementById("table-body");
    table.innerHTML = "";
    for (let count = 0; count < users.length; count++) {
        let template = `<tr>
                <td>${count}</td>
                <td>${users[count].name}</td>
                <td>${users[count].secondName}</td>
                <td>${users[count].email}</td>
                <td><button id="button${count}" type="button" class="btn btn-danger deleteBtn">delete</button></td>
                <td><button id="buttonEd${count}" type="button" class="btn btn-warning editBtn">edit</button></td>
                </tr>`
        table.innerHTML += template;
    }

    let btn2 = document.querySelectorAll(".deleteBtn");
    for (let btnCount = 0; btnCount < btn2.length; btnCount++) {
        btn2[btnCount].addEventListener("click", (btnCount) => deleteUser(btnCount));
    }

    let btn3 = document.querySelectorAll(".editBtn");
    for (let btnCountEd = 0; btnCountEd < btn3.length; btnCountEd++) {
        btn3[btnCountEd].addEventListener("click", (btnCountEd) => editUser(btnCountEd));
    }


}

const clearField = () => {
    let name = document.getElementById("name-input");
    let secondName = document.getElementById("second-name-input");
    let email = document.getElementById("email-input");
    let button = document.getElementById("submit-button");
    button.disabled = true;
    name.value = "";
    secondName.value = "";
    email.value = "";

}



const validateName = () => {

    let nameField = document.getElementById("name-input");
    let nameError = document.getElementById("name-errors");
    let errors = checkNameAndSecondNameErrors(nameField.value);
    nameError.textContent = errors;

}

const validateSecondName = () => {

    let secondNameField = document.getElementById("second-name-input");
    let nameError = document.getElementById("second-name-errors");
    let errors = checkNameAndSecondNameErrors(secondNameField.value);
    nameError.textContent = errors;

}


const checkNameAndSecondNameErrors = (input) => {
    let errors = "";
    if (specialChars.test(input)) {
        errors += "Symbols are not accepted.";
    }
    if (input === "") {
        errors += "This field can not be empty";
    }
    return errors;
}

const validateEmail = (input) => {
    let errors = "";
    let emailField = document.getElementById("email-input");
    let nameError = document.getElementById("email-errors");
    let emailInput = emailField.value;
    let emails = [];
    users.forEach(element => {
        emails.push(element.email)
    });
    console.log(emails);

    if (emails.includes(emailInput)) {
        errors += "Email belongs to an existing account.";
    }

    if (!emailInput.match(validEmail)) {
        errors += "Email is not valid";
    }

    nameError.textContent = errors;
}

const enableSubmit = () => {
    let button = document.getElementById("submit-button");
    let nameErrorField = document.getElementById("name-errors");
    let secondNameErrorField = document.getElementById("second-name-errors");
    let emailErrorField = document.getElementById("email-errors");
    if (nameErrorField.textContent.length === 0 && secondNameErrorField.textContent.length === 0 && emailErrorField.textContent === "") {
        button.disabled = false;
    }
    else {
        button.disabled = true;
    }

}







