//const { type } = require("jquery");

function deleteEmployee(empId) {
    $.ajax({
        //type: 'GET',
        type: 'PUT',
        url: '/Home/DeleteEmployee/?empId=' + empId,
        data: {},
        success: function (data) {
            alert('Employee ID: ' + empId + ' was deleted.');
            window.location.reload();
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    });

    // JavaScriptObjectNotiation
}

function updateEmployee(rowId) {
    var fName = $('#' + rowId).find('[name="fName"]').val();
    var lName = $('#' + rowId).find('[name="lName"]').val();
    var empId = rowId.replace('tr_', ''); // $('#' + rowId).find('[name="empId"]').val();

    var employee = {
        First_Name: fName,
        Last_Name: lName,
        //Dept_Id: '',
        Emp_Id: empId
    };

    //debugger;
    $.ajax({
        //type: 'GET',
        type: 'POST',
        url: '/Home/UpsertEmployee/',
        //data: {},
        data: JSON.stringify(employee),   //** stringify means converting a JS object or value to a JSON string
        success: function (data) {
            //debugger;
            alert('Employee ID: ' + empId + ' was updated.');
            window.location.reload();
        },
        //catch: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8"
    });
}

function saveEmployee() {
    var fName = document.getElementById('fName').value;
    var lName = document.getElementById('lName').value;
    var newEmpDepoId = document.getElementById('depoItem').value;

    var employee = {
        First_Name: fName,
        Last_Name: lName,
        Dept_Id: newEmpDepoId
    };

    $.ajax({
        type: 'POST',
        url: '/Home/UpsertEmployee/',
        data: JSON.stringify(employee),
        success: function (data) {
            alert('Employee ' + fName + ' was saved.');
            window.location.reload();
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    });
}

function search() {
    var searchTerm = document.getElementById('txtSearch').value;

    window.location.href = "/Home/Index/?searchTerm=" + encodeURIComponent(searchTerm);
}