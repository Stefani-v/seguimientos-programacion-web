// Simple animation on adding tasks
document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector("form[asp-action='Add']");
    if (form) {
        form.addEventListener("submit", () => {
            setTimeout(() => {
                window.scrollTo({ top: 0, behavior: "smooth" });
            }, 100);
        });
    }
});
//El formulario se envía (se llama a tu método Add en el controlador).
//Se redirige a la vista Index nuevamente.
//Justo en ese momento, este script hace que la página se desplace suavemente hacia arriba para que veas la lista actualizada de tareas 
//sin tener que subir manualmente.