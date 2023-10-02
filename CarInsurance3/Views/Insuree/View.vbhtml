public ActionResult Admin()
{
    // Retrieve quotes issued along with user's information from the database.
    using (var dbContext = new YourDbContext()) // Replace with your DbContext class name
    {
        var adminQuotes = dbContext.Insurees
            .Select(insuree => new AdminQuoteViewModel
            {
                FirstName = insuree.FirstName,
                LastName = insuree.LastName,
                Email = insuree.Email,
                Quote = insuree.Quote
            })
            .ToList();

        return View(adminQuotes);
    }
}
