var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url": "NationalPark/GetAll",
            "type": "GET",
            "datatype":"json"
        },
        "columns": [
            { "data": "name", "width": "40%" },
            { "data": "state", "width": "40%" },

            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                        <a href="NationalPark/Upsert/${data}" class="btn btn-info">
                        <i class="fa fa-edit"></i>
                        </a>
                        <a class="btn btn-danger" onclick=Delete("NationalPark/Delete/${data}")>
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
