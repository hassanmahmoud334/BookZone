$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        ajax: { url: '/admin/product/getall' },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "author", "width": "10%" },
            { "data": "description", "width": "15%" },
            { "data": "price", "width": "10%" },
            { "data": "discount", "width": "10%" },
            { "data": "priceWithDiscount", "width": "10%" },
            { "data": "quantity", "width": "10%" },
            //{ "data": "productCategories", "width": "10%" },
            {
                "data": 'id',
                "render": function (data) {
                    return `<div class="w-25 btn-group" role="group" >
						<a href="/admin/product/edit?id=${data}" class="btn btn-outline-info rounded rounded-3 me-2 px-3 py-3" >
							<i class="bi bi-pencil-square"></i>
                            Edit
						</a>
						<a href="/admin/product/delete?id=${data}" class="btn btn-outline-danger rounded rounded-3 px-2 py-3"> 
							<i class="bi bi-trash3"></i>
                            Delete
						</a>
					</div>`
                },
                "width":"20%"
            }
        ]
    });
}