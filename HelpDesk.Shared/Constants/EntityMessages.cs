using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Shared.Constants
{
    public static class EntityMessages
    {
        public static string GetAll(string entity) => $"{entity} obtenidas correctamente.";
        public static string Get(string entity) => $"{entity} obtenida correctamente.";
        public static string Created(string entity) => $"{entity} registrado correctamente.";
        public static string Updated(string entity) => $"{entity} actualizado correctamente.";
        public static string Deleted(string entity) => $"{entity} eliminado correctamente.";
        public static string NotFound(string entity) => $"No se econtro el {entity.ToLower()} solicitada.";
        public static string AlreadyExist(string entity) => $"Ya existe un {entity.ToLower()} con ese código.";
    }
}
