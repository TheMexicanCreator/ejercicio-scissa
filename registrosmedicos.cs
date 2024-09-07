namespace ejercicio_scissa;

public class Cliente
{
    public int ClienteID { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
}

public class Vehiculo
{
    public int VehículoID { get; set; }
    public int ClienteID { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
    public string Placa { get; set; }
}

public class Cita
{
    public int CitaID { get; set; }
    public int VehículoID { get; set; }
    public DateTime Fecha { get; set; }
    public string Estado { get; set; }
    public string Comentario { get; set; }
    public DateTime? FechaTerminacion { get; set; }
}

public class Administrador
{
    public int AdminID { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Contrasena { get; set; }
}

