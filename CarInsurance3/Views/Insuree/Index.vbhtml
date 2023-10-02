@ModelType IEnumerable(Of CarInsurance3.Insuree)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LastName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EmailAddress)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateOfBirth)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CarYear)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CarMake)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CarModel)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DUI)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SpeedingTickets)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CoverageType)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Quote)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FirstName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LastName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EmailAddress)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DateOfBirth)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CarYear)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CarMake)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CarModel)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DUI)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SpeedingTickets)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CoverageType)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Quote)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
