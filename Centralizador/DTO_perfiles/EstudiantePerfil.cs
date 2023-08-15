﻿using AutoMapper;
using Centralizador.DTO;
using Centralizador.Models;

namespace Centralizador.DTO_perfiles
{
    public class EstudiantePerfil : Profile
    {
        public EstudiantePerfil()
        {
            CreateMap<Estudiante, EstudianteReadDTO>();
        }
    }
}
