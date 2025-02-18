namespace CIPA.Models
{
    // Classe estática que serve como um repositório em memória para armazenar candidatos
    public static class DataStore
    {
        // Lista estática de candidatos
        // Esta lista é compartilhada em toda a aplicação e simula um banco de dados em memória
        public static List<Candidato> Candidatos { get; set; } = new List<Candidato>();
    }
}