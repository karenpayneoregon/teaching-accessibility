var $tableGenerator = $tableGenerator || {};
$tableGenerator = function() {
    const mainTable = function(document) {
        // Create the table element
        let table = document.createElement('table');
        table.className = 'table table-light table-bordered caption-top mb-3 shadow';

        // Create the caption
        let caption = document.createElement('caption');
        caption.className = 'visually-hidden position-relative';
        caption.textContent = 'First table';
        table.appendChild(caption);

        // Create the table header
        let thead = document.createElement('thead');
        thead.className = 'table-success';

        let headers = ["First name", "Name", "Gender"];
        let tr = document.createElement('tr');

        headers.forEach(headerText => {
            let th = document.createElement('th');
            th.scope = 'col';
            th.textContent = headerText;
            tr.appendChild(th);
        });

        thead.appendChild(tr);
        table.appendChild(thead);

        // Create the table body with rows
        const rows = [
            { firstName: "Mike", name: "Jones", gender: "Male" },
            { firstName: "Glen", name: "Frey", gender: "Male" },
            { firstName: "Jill", name: "Adams", gender: "Female" },
            { firstName: "Mary", name: "Blocker", gender: "Female" },
            { firstName: "Anne", name: "White", gender: "Female" }
        ];

        rows.forEach(rowData => {
            let tr = document.createElement("tr");
            Object.values(rowData).forEach(cellData => {
                let td = document.createElement("td");
                td.textContent = cellData;
                tr.appendChild(td);
            });
            table.appendChild(tr);
        });

        // Append the table to the div with the id "TheTable"
        document.getElementById("TheTable").appendChild(table);
    };
    return { mainTable: mainTable };
}();
