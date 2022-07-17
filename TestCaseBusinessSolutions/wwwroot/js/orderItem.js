var dataTable;
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/OrderItem/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "quantity", "width": "15%" },
            { "data": "unit", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                       <div class="w-75 h-75 btn-group" role="group">
                        <a href="/OrderItem/Upsert?id=${data}"
                        class="btn btn-primary mx-2" ><i class="bi bi-pencil-square"></i></a>
                    </div>
                     `
                },
                "width": "15%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                       <div class="w-75 h-75 btn-group" role="group">
                        <a href="/OrderItem/Delete?id=${data}"
                        class="btn btn-primary mx-2" ><i class="bi bi-trash"></i></a>
                    </div>
                     `
                },
                "width": "15%"
            },

        ]
    });
}