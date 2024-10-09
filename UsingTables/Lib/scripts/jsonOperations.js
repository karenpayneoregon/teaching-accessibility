/*
 * For debugging purposes
 */
function readJsonFile(file) {
    const request = new XMLHttpRequest();
    request.open('GET', file, false);
    request.send(null);
    var json = JSON.parse(request.responseText);

    Object.keys(json).forEach(function (key) {
        console.log(`Id : ${json[key].userId}, Name : ${json[key].firstName} ${json[key].lastName} Gender: ${json[key].lastName}`);
    });

    return json;

}

//----------------------------------------------------------------------------------------------------------------
var $jsonHelpers = $jsonHelpers || {};
$jsonHelpers = function () {
    var getJson = function (file) {
        var request = new XMLHttpRequest();
        request.open('GET', file, false);
        request.send(null);
        var json = JSON.parse(request.responseText);
        return json;
    }

    var createDynamicTableWithJsonData = function (document) {
        const dynamicTable = document.createElement('table');

        // setup with Bootstrap 5 classes
        dynamicTable.className = 'table table-light table-bordered mb-3 shadow';

        const thead = document.createElement('thead');
        thead.className = 'table-primary';

        const row = document.createElement('tr');

        const firstNameCell = document.createElement('th');
        firstNameCell.textContent = "First name";
        firstNameCell.scope = "col";

        const nameCell = document.createElement('th');
        nameCell.textContent = "Name";
        nameCell.scope = "col";

        const genderCell = document.createElement('th');
        genderCell.textContent = "Gender";
        genderCell.scope = "col";

        row.appendChild(firstNameCell);
        row.appendChild(nameCell);
        row.appendChild(genderCell);
        thead.appendChild(row);

        dynamicTable.appendChild(thead);

        // read json file with people
        var json = getJson('people.json');

        for (let index = 0; index < json.length; index++) {

            const row = document.createElement('tr');

            const cell0 = row.insertCell(0);
            cell0.innerHTML = json[index].firstName;
            const cell1 = row.insertCell(1);
            cell1.innerHTML = json[index].lastName;
            const cell2 = row.insertCell(2);
            cell2.innerHTML = json[index].gender;

            dynamicTable.appendChild(row);
        }

        document.getElementById('main_table').appendChild(dynamicTable);
    }

    // exposed methods
    return {
        getJson: getJson,
        createDynamicTableWithJsonData: createDynamicTableWithJsonData
    };
}();