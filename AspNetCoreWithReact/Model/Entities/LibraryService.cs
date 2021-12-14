using AspNetCoreWithReact.Data;

namespace AspNetCoreWithReact.Model.Entities
{
    public class LibraryService : ILibraryService
    {
        public DataContext _context;

        public LibraryService(DataContext context)
        {
            _context = context;
        }

        public List<Library> GetAll()
        {
            return _context.Libraries.ToList();
        }

        public List<Library> GetByName(string name)
        {
            var linq = from libraries in _context.Libraries select libraries;
            if (!string.IsNullOrWhiteSpace(name))
            {
                linq = linq.Where(x => x.Name.ToUpper().Contains(name.ToUpper()));

            }

            return linq.ToList();
        }

        public Library Save(Library library)
        {
            _context.Libraries.Add(library);
            _context.SaveChanges();

            return library;
        }

        public Library Update(Library library)
        {
            Library libraryUpdate = _context.Libraries.First(x => x.Id == library.Id);
            _context.Entry(libraryUpdate).CurrentValues.SetValues(library);
            _context.SaveChanges();
            return library;
        }

        public void Delete(Library library)
        {
            _context.Entry(library).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
