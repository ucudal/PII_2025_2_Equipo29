namespace CrmUcu.Repositories
{
    //abstracción para los repos en general
    public abstract class Repositorio<T>
    {
        protected List<T> elementos = new();
        
        public abstract void Agregar(T elemento);
        public abstract List<T> Buscar(string filtro);
        public abstract List<T> ObtenerTodos();
        public abstract void Eliminar(int id);
        public abstract void Editar(T elemento);
    }
}
