using Catalog.Core.DTOs;
using Catalog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappers
{
    public static class TypeMapper
    {
        public static List<TypeDTO> ToTypeMappers
           (this List<TypeModel> typeModels)
        {

            List<TypeDTO> typeDTOs = null;

            //Check your Object is null or not
            if (typeModels != null)
            {
                //it will create object for DTO
                typeDTOs = new List<TypeDTO>();
                foreach (TypeModel typeModel in typeModels)
                {
                    typeDTOs.Add(typeModel.ToTypeMapper());
                }
            }

            //it will return TypeDTO as an output
            return typeDTOs;
        }

        public static TypeDTO ToTypeMapper
            (this TypeModel typeModel)
        {
            TypeDTO typeDTO = null;

            if (typeModel != null)
            {
                typeDTO = new TypeDTO(
                    typeModel.Id,
                    typeModel.Name);
            }

            return typeDTO;
        }
    }
}
