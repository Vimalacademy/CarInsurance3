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
    Public Class InsureeController
        Inherits System.Web.Mvc.Controller

        Private db As New InsuranceEntities

        ' GET: Insuree
        Function Index() As ActionResult
            Return View(db.Insurees.ToList())
        End Function

        ' GET: Insuree/Details/5
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

        ' GET: Insuree/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Insuree/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")> ByVal insuree As Insuree) As ActionResult
            If ModelState.IsValid Then
                db.Insurees.Add(insuree)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(insuree)
        End Function

        ' GET: Insuree/Edit/5
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

        ' POST: Insuree/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")> ByVal insuree As Insuree) As ActionResult
            If ModelState.IsValid Then
                db.Entry(insuree).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(insuree)
        End Function

        ' GET: Insuree/Delete/5
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

        ' POST: Insuree/Delete/5
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
