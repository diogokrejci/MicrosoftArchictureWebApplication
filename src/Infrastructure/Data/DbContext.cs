using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    /// <summary>
    /// Passo1: criar o construtor com parametros option
    /// 
    /// Passo 2: Criar o DbSet referente a cada entidade
    /// 
    /// Passo 3: Criar o método OnModelCreating
    /// 
    /// Passo 4: Inicializar o Contexto no Startup da UI
    /// 
    /// Passo 5: Fazer o mapeamento (Migrations)
    /// 
    ///     
    ///     - No powershell: add-migration nomeMigracao
    ///         Ex: add-migration Inicial
    /// 
    ///     - Caso você tenha mais de um contexto, você deverá definir qual contexto usar 
    ///         add-migration -Context nomeContexto nomeMigracao
    ///      Ex: add-migration -Context DataBaseContext Inicial
    /// 
    ///     No package Manage, você deve apontar para o projeto de Infra
    /// 
    ///     Resultado: Irá criar uma classe que fara o mapemento para o banco
    /// 
    /// </summary>
    public class DataBaseContext : DbContext
    {
        //Passo 1
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        //Passo 2
        public DbSet<Cliente> Clientes { get; set; } 


        //Passo 3
        /// <summary>
        /// Método responsável pela configuração do Entity Framework
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Diz como será o nome da tabela gerada a partir do DbSet
            // Se fosse automático, seria Clientes. Porém, sabemos que não existe plural em nome de tabelas do Banco
            modelBuilder.Entity<Cliente>().ToTable("Cliente");  
        }
    }
}
