using System;
using System.Collections.Generic;
using System.Text;
using ddelgadoS5.Models;

namespace ddelgadoS5.Repositories
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLite.SQLiteConnection _conn;
        public string StatusMessage { get; set; }

        public PersonRepository(string path)
        {
            _dbPath = path;
        }

        private void Init()
        {
            if (_conn is not null)
                return;
            _conn = new(_dbPath);
            _conn.CreateTable<Persona>();
        }

        //INSERT / UPDATE
        public void AddNewPerson(string name)
        {
            int result;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");
                Persona persona = new() { Name = name };
                result = _conn.Insert(persona);
                StatusMessage = string.Format("Dato ingresado");
            }
            catch (Exception ex)
            {
               StatusMessage = string.Format("Error " + ex.Message);
            }
        }

        //SELECT
        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return _conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error " + ex.Message);
            }
            return new List<Persona>();
        }

        //DELETE (Taller en clase)
        public void DeletePerson(int id)
        {
            int result;
            try
            {
                Init();
                if (id <= 0)
                    throw new Exception("Error con el ID seleccionado");
                result = _conn.Delete<Persona>(id);

                if (result > 0)
                {
                    StatusMessage = string.Format("Registro eliminado");
                }
                else
                {
                    StatusMessage = string.Format("No se encontró el registro a eliminar");
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error " + ex.Message);
            }
        }

        //PRE-UPDATE (Tarea)
        public void EditPerson(int id, string name)
        {
            int result;
            try
            {
                Init();

                if (id <= 0)
                    throw new Exception("Error con el ID seleccionado");

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");

                Persona persona = new()
                {
                    Id = id,
                    Name = name
                };

                result = _conn.Update(persona);

                if (result > 0)
                {
                    StatusMessage = string.Format("Registro editado");
                }
                else
                {
                    StatusMessage = string.Format("No se encontró el registro a editar");
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error " + ex.Message);
            }
        }
    }

}
