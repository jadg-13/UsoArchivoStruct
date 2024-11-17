using Registro.Estructuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Dao
{
    internal class CiudadDao
    {
        private List<Ciudad> ciudades;

        public CiudadDao()
        {
            ciudades = new List<Ciudad>();
        }

        public void Agregar(Ciudad ciudad)
        {
            ciudades.Add(ciudad);
        }

        public void Actualizar(Ciudad ciudad)
        {
            int index = ciudades.FindIndex(item => item.ID == ciudad.ID);

            if (index != -1)
            {
                ciudades[index] = ciudad;
            }
        }

        public List<Ciudad> Listar()
        {
            return ciudades;
        }

        public void SetList(List<Ciudad> list)
        {
            ciudades = list;
        }

        public Ciudad Buscar(int id)
        {
            return ciudades.Find(item => item.ID == id);
        }

        public int BuscarIndex(int id)
        {
            return ciudades.FindIndex(item => item.ID == id);
        }

        public void Eliminar(Ciudad ciudad)
        {
            ciudades.Remove(ciudad);
        }

        public void Ordenar()
        {
            ciudades.Sort((x, y) => x.Nombre.CompareTo(y.Nombre));
        }

    }
}
