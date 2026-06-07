<section class="section2">
    <div class="row">

        <div class="primero col-6">
            <h3>RESERVA TU MOMENTO</h3>
            <p>En <strong>Inspire Beauty</strong> queremos ofrecerte una experiencia única y personalizada desde
                el primer instante. Gestiona tu solicitud de cita previa de forma online en menos de un minuto.
            </p>

            <h4>INFORMACIÓN IMPORTANTE:</h4>
            <ul class="lista-condiciones">
                <li>🕒 <strong>Confirmación:</strong> Tras recibir tu solicitud, nuestro equipo se pondrá en
                    contacto contigo para confirmar la hora exacta de tu sesión.</li>
                <li>❌ <strong>Cancelaciones:</strong> Si no puedes asistir, por favor avísanos con un mínimo de
                    24 horas de antelación para liberar la cabina.</li>
                <li>📍 <strong>Puntualidad:</strong> Recomendamos llegar 5 minutos antes para garantizar la
                    duración completa de tu tratamiento.</li>
            </ul>

            <h4>NUESTRO HORARIO DE ATENCIÓN:</h4>
            <div class="grid-horario">
                <p><strong>Lunes a Viernes:</strong> 09:00h - 20:00h</p>
                <p><strong>Sábados:</strong> 10:00h - 14:00h</p>
                <p><strong>Domingos:</strong> Cerrado</p>
            </div>

            <h1 class="marca-agua">Inspire Beauty</h1>
        </div>

        <div class="segundo col-6">
            <h4>SOLICITA TU CITA:</h4>
            
            <?php if (isset($_SESSION['error'])): ?>
                <div style="color: red; margin-bottom: 15px; font-weight: bold;">
                    <?= htmlspecialchars($_SESSION['error']); unset($_SESSION['error']); ?>
                </div>
            <?php endif; ?>
            
            <?php if (isset($_SESSION['success'])): ?>
                <div style="color: green; margin-bottom: 15px; font-weight: bold;">
                    <?= htmlspecialchars($_SESSION['success']); unset($_SESSION['success']); ?>
                </div>
            <?php endif; ?>

            <form class="form-contacto" id="formReserva" action="/reservar" method="POST" novalidate>
                <input type="text" id="nombreReserva" name="nombre" placeholder="Nombre y apellidos*" required>
                <input type="email" id="emailReserva" name="email" placeholder="Email*" required>
                <input type="tel" id="telefonoReserva" name="telefono" placeholder="Teléfono*" required>

                <!-- Tratamientos cargados dinámicamente desde BD -->
                <select id="selectServicio" name="treatment_id" required>
                    <option value="" disabled selected>Selecciona un tratamiento*</option>
                    <?php foreach ($treatments as $treatment): ?>
                        <option value="<?= htmlspecialchars($treatment['id']) ?>">
                            <?= htmlspecialchars($treatment['name']) ?> (<?= htmlspecialchars($treatment['duration_minutes']) ?> min)
                        </option>
                    <?php endforeach; ?>
                </select>

                <input type="date" id="fechaCita" name="fecha" required>
                <!-- Selector de hora dinámico -->
                <select id="horaCita" name="hora" required>
                    <option value="">Selecciona fecha primero</option>
                </select>

                <textarea id="mensajeReserva" name="comentarios"
                    placeholder="Notas adicionales o preferencias médicas..."></textarea>

                <button type="submit" class="btn-enviar">Solicitar Cita</button>
            </form>
            <p>*Campos obligatorios</p>
        </div>

    </div>
</section>

<script>
document.addEventListener('DOMContentLoaded', function() {
    const dateInput = document.getElementById('fechaCita');
    const timeSelect = document.getElementById('horaCita');
    const formReserva = document.getElementById('formReserva');

    if (dateInput && timeSelect) {
        // Bloquear fechas anteriores a hoy
        const today = new Date().toISOString().split('T')[0];
        dateInput.min = today;

        dateInput.addEventListener('change', function() {
            const d = new Date(this.value);
            const day = d.getDay(); // 0 = Domingo
            
            timeSelect.innerHTML = ''; // Limpiar
            
            if (day === 0) {
                Swal.fire({title: 'Atención', text: 'El centro está cerrado los domingos.', icon: 'warning', confirmButtonColor: 'var(--color-dark)'});
                timeSelect.innerHTML = '<option value="">Cerrado</option>';
                return;
            }
            
            let startHour = 9, endHour = 20; // L-V
            if (day === 6) { // Sábado
                startHour = 10;
                endHour = 14;
            }
            
            timeSelect.innerHTML = '<option value="">Selecciona hora</option>';
            for (let h = startHour; h < endHour; h++) {
                ['00', '15', '30', '45'].forEach(m => {
                    const timeStr = String(h).padStart(2, '0') + ':' + m;
                    timeSelect.innerHTML += `<option value="${timeStr}">${timeStr}</option>`;
                });
            }
        });
    }

    if (formReserva) {
        formReserva.addEventListener('submit', function(e) {
            const dateStr = dateInput.value;
            const timeStr = timeSelect.value;
            
            if (dateStr) {
                const d = new Date(dateStr);
                if (d.getDay() === 0) {
                    e.preventDefault();
                    Swal.fire({title: 'No permitido', text: 'No se puede programar citas: El centro está cerrado los domingos.', icon: 'error', confirmButtonColor: 'var(--color-dark)'});
                    return;
                }
            }
            
            if (!timeStr) {
                e.preventDefault();
                Swal.fire({title: 'Faltan datos', text: 'Por favor, selecciona una hora válida.', icon: 'warning', confirmButtonColor: 'var(--color-dark)'});
            }
        });
    }
});
</script>
