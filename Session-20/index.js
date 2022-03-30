//Question 1
function reverseString(str){
    return str.split("").reverse().join("");
}
//-----------------------------------

//Question 2
function checkIsPalindrome(str){
    str = str.toLowerCase().split(" ").join("");
    let len = str.length;
    for(let i=0; i < len/2; i++){
        if(str[i] !== str[len - 1 - i]){
            return false;
        }
    }
    return true;
}
//------------------------------------

//Question 3
var counter = 0;
let customers = [];
function addCustomer(){
    let id = counter;
    counter++;
    let name = document.getElementById("txtInputName").value;
    let surname = document.getElementById("txtInputSurname").value;
    let age = document.getElementById("txtInputAge").value;
    let gender = document.querySelector('input[name="gender"]:checked').value;
    let customer = {id, name, surname, age, gender};
    customers.push(customer);
    showCustomers();   
}

function showCustomers(){
    var customersTable = document.getElementById("listCustomers");
    customersTable.innerText = "";
    customers.forEach(c => {
        let li = document.createElement("li");
        li.appendChild(document.createTextNode(c.name));
        li.setAttribute('id', c.id);
        li.setAttribute('data-id', c.id);   
        li.addEventListener('click', (event) => {
            customerInfo(event);
        })
        customersTable.appendChild(li);
    });
}

function customerInfo(e){
    let selectedId = +e.target.dataset.id;
    let selectedItem = findItemById(selectedId);
    document.getElementById("infoName").value = selectedItem.name;
    document.getElementById("infoSurname").value = selectedItem.surname;
    document.getElementById("infoAge").value = selectedItem.age;
    document.getElementById("infoGender").value = selectedItem.gender;
}

function findItemById(id){
    return customers.find(c => c.id === id);
}
//-----------------------------------------------------------------

//Question 4
function multiply(a, b){
    return a*b;
}
//-----------------------------------------------------------------

//Question 5

//use regex
function incrementString(str){
    if(endsWithNumber(str)){
        let nextNum = getNumberAtTheEnd(str) + 1;
        return str.replace(/\d+$/, "") + nextNum.toString();
    }
    return str + "1";
}

//use regex and test() function
function endsWithNumber(str){
    return /[0-9]+$/.test(str);
}

//use regex
function getNumberAtTheEnd(str){
    return Number(str.match(/[0-9]+$/)[0]);
}