
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": { url: '/employee/getall'},
        "columns": [
            { data: 'id', "width": "17%" },
            { data: 'name', "width": "17%" },
            { data: 'dateOfJoin', "width": "17%" },
            { data: 'department', "width": "17%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/employee/edit?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>               
                     <a href="/employee/delete?id=${data}" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "32%"
            }
        ]
    });
};