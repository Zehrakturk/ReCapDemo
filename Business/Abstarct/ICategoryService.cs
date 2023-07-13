﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface ICategoryService
    {
       IDataResult<List<Category>> GetAll();
       IDataResult<Category> GetById(int categoryId);

    }
}
