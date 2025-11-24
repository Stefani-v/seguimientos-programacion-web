using NotesManager.Models;

namespace NotesManager.Data
{
    public static class NoteRepository
    {
        private static List<Note> notes = new List<Note>();

        public static List<Note> GetAll() => notes;

        public static void Add(Note note)
        {
            note.Id = notes.Count == 0 ? 1 : notes.Max(n => n.Id) + 1;
            notes.Add(note);
        }

        public static Note GetById(int id) => notes.FirstOrDefault(n => n.Id == id);

        public static void Delete(int id)
        {
            var note = GetById(id);
            if (note != null)
                notes.Remove(note);
        }

        public static List<Note> Search(string query)
        {
            return notes
                .Where(n =>
                    n.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    n.Content.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    n.Category.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}

