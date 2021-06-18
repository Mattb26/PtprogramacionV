using Entidades;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class Conectado
    {
        public DataTable Mododesconectado()
        {
            Dato.Conectado conectado = new Dato.Conectado();
            return conectado.Mododesconectado();
        }


        public List< UserApp> ModoConectado()
        {
            Dato.Conectado conectado = new Dato.Conectado();
            return conectado.ModoConectado();
        }
    }
}
