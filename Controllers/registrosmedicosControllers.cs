using Microsoft.AspNetCore.Mvc;

namespace ejercicio_scissa.Controllers;

[ApiController]
[Route("[controller]")]
public class CitasController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Citas/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Citas/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "VehículoID,Fecha,Estado,Comentario,FechaTerminacion")] Cita cita)
    {
        if (ModelState.IsValid)
        {
            // Validar disponibilidad de la hora
            if (IsSlotAvailable(cita.Fecha))
            {
                db.Citas.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "La hora seleccionada ya está ocupada.");
            }
        }
        return View(cita);
    }

    private bool IsSlotAvailable(DateTime fecha)
    {
        var existingCita = db.Citas.FirstOrDefault(c => c.Fecha <= fecha && fecha < c.Fecha.AddHours(2));
        return existingCita == null;
    }
}

public static string ComputeMD5Hash(string input)
{
    using (MD5 md5 = MD5.Create())
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
}
