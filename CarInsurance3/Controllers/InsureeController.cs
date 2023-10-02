Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports CarInsurance3

Namespace Controllers
    Public Class InsureesController
        Inherits System.Web.Mvc.Controller

        Private db As New InsuranceEntities

        ' GET: Insurees
        Function Index() As ActionResult
            Return View(db.Insurees.ToList())
        End Function

        ' GET: Insurees/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim insuree As Insuree = db.Insurees.Find(id)
            If IsNothing(insuree) Then
                Return HttpNotFound()
            End If
            Return View(insuree)
        End Function

        ' GET: Insurees/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Insurees/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        public ActionResult CalculateQuote(InsureeViewModel viewModel)
{
    decimal monthlyTotal = 50;
    if (viewModel.Age <= 18)
    {
        monthlyTotal += 100;
    }
    else if (viewModel.Age >= 19 && viewModel.Age <= 25)
    {
        monthlyTotal += 50;
    }
    else
    {
        monthlyTotal += 25;
    }
    if (viewModel.CarYear < 2000)
    {
        monthlyTotal += 25;
    }
    else if (viewModel.CarYear > 2015)
    {
        monthlyTotal += 25;
    }
    if (viewModel.CarMake == "Porsche")
    {
        monthlyTotal += 25;

        if (viewModel.CarModel == "911 Carrera")
        {
            monthlyTotal += 25;
        }
    }
    monthlyTotal += viewModel.SpeedingTickets * 10;
    if (viewModel.HasDUI)
    {
        monthlyTotal *= 1.25M; // Add 25%
    }
    if (viewModel.CoverageType == "Full")
    {
        monthlyTotal *= 1.5M; // Add 50%
    }
    ViewBag.Quote = monthlyTotal;

    return View("QuoteResult");
}
public ActionResult Admin()
{
    var quotes = dbContext.Insurees
        .Select(insuree => new AdminViewModel
        {
            FirstName = insuree.FirstName,
            LastName = insuree.LastName,
            Email = insuree.Email,
            Quote = insuree.Quote
        })
        .ToList();

    return View(quotes);
}

' GET: Insurees/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim insuree As Insuree = db.Insurees.Find(id)
            If IsNothing(insuree) Then
                Return HttpNotFound()
            End If
            Return View(insuree)
        End Function

        ' POST: Insurees/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")> ByVal insuree As Insuree) As ActionResult
            If ModelState.IsValid Then
                db.Entry(insuree).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(insuree)
        End Function

        ' GET: Insurees/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim insuree As Insuree = db.Insurees.Find(id)
            If IsNothing(insuree) Then
                Return HttpNotFound()
            End If
            Return View(insuree)
        End Function

        ' POST: Insurees/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim insuree As Insuree = db.Insurees.Find(id)
            db.Insurees.Remove(insuree)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
