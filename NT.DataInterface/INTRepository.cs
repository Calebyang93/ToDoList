using NT.Model;
using System;
using System.Collections.Generic;

namespace NT.DataInterface
{
  public interface INTRepository
  {
    void DeleteById(Guid id);
    void Delete(Note n);
    List<Note> GetAll();
    void Insert(Note n);
    void Update(Note n);    
  }
}
