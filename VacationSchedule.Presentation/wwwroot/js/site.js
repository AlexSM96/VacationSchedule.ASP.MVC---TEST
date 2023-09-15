function showModal(parameters) {
    const url = parameters.url
    const employeeId = parameters.data
    const modal = $('#modal')

    $.ajax({
        type: 'GET',
        url: url,
        data: { employeeId },
        success: function (response) {
            modal.find('.modal-body').html(response)
            modal.modal('show')
        },
        error: (response) => console.log(response)
    })
}

function openAddVacationModal(employeeId) {
    const modal = $('#modal')

    $.ajax({
        type: 'GET',
        url: '/Home/AddVacation',
        data: { employeeId },
        success: function (response) {
            modal.find('.modal-body').html(response)
            modal.modal('show')
        },
        error: (response) => console.log(response)
    })
}

$(document).on('submit', '#addVacationForm', function (e) {
    e.preventDefault()
    const form = $(this)
    let formData = form.serialize()

    $.ajax({
        url: '/Home/AddVacation',
        type: "POST",
        data: formData,
        success: function (response) {
            $("#modalContainer").html(response)
        },
        error: (xhr) => console.log(xhr.responseText)
    })
})