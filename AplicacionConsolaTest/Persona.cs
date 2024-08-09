using System.Diagnostics;

namespace testingCode
{
    [DebuggerDisplay("{Nombre}")]
    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public bool Soltero { get; set; }
        public DateTime FechaIngresoALaEmpresa { get; set; }
        public List<string> Telefonos = new List<string>();
        public int EmpresaId { get; set; }
    }
}