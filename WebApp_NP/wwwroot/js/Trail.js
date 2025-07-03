var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url": "Trail/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "nationalPark.name", "width": "20%" },
            { "data": "name", "width": "20%" },
            { "data": "distance", "width": "20%" },
            { "data": "elevation", "width": "20%" },
            

            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                        <a href="Trail/Upsert/${data}" class="btn btn-info">
                        <i class="fa fa-edit"></i>
                        </a>
                        <a class="btn btn-danger" onclick=Delete("Trail/Delete/${data}")>
                        <i class="fa fa-trash-alt"></i>
                        </a>
                        </div>

                    `;
                }
            }

        ]
    })
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    Swal.fire(
                        'Deleted!',
                        'Your item has been deleted.',
                        'success'
                    )
                }
            });
        }
    });
}
