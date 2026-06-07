<?php
namespace App\Controllers;

use Core\Controller;
use App\Models\Treatment;

class AppointmentController extends Controller {
    // Mostrar el formulario de reservas
    public function book() {
        // Obtenemos todos los tratamientos para mostrarlos en el select
        $treatments = Treatment::getAll();
        
        $this->render('appointments/book', [
            'title' => 'Reservar Cita - Inspire Beauty',
            'extraCss' => ['/css/estilos2.css', '/css/reserva.css'],
            'treatments' => $treatments
        ]);
    }

    // Procesar la solicitud de reserva
    public function store() {
        if (!isset($_SESSION['user_id'])) {
            $_SESSION['error'] = 'Debes iniciar sesión para reservar una cita.';
            header('Location: /login');
            exit;
        }

        $userId = $_SESSION['user_id'];
        $treatmentId = $_POST['treatment_id'] ?? null;
        $date = $_POST['fecha'] ?? null;
        $time = $_POST['hora'] ?? null;
        
        if (!$treatmentId || !$date || !$time) {
            $_SESSION['error'] = 'Faltan datos obligatorios.';
            header('Location: /reservar');
            exit;
        }
        
        // Validar fecha pasada
        if (strtotime($date . ' ' . $time) < time()) {
            $_SESSION['error'] = 'No puedes reservar en una fecha u hora pasada.';
            header('Location: /reservar');
            exit;
        }

        $result = \App\Models\Appointment::create($userId, $treatmentId, $date, $time);
        
        if ($result['success']) {
            // Enviar email de confirmación
            $db = \Core\Database::getConnection();
            $stmtUser = $db->prepare("SELECT name, email FROM users WHERE id = ?");
            $stmtUser->execute([$userId]);
            $user = $stmtUser->fetch();
            
            $stmtTreat = $db->prepare("SELECT name, duration_minutes FROM treatments WHERE id = ?");
            $stmtTreat->execute([$treatmentId]);
            $treatment = $stmtTreat->fetch();
            
            if ($user && !empty($user['email']) && $treatment) {
                $emailId = \Core\EmailService::sendBookingConfirmation(
                    $user['email'],
                    $user['name'],
                    $treatment['name'],
                    $date,
                    $time,
                    $treatment['duration_minutes']
                );
                
                $link = "<br><a href='/ver-correo?id=$emailId' target='_blank' style='display:inline-block; margin-top:10px; background:#0366d6; color:white; padding:5px 10px; border-radius:3px; text-decoration:none;'>📧 Ver correo enviado al cliente</a>";
                $_SESSION['success'] = $result['message'] . $link;
            } else {
                $_SESSION['success'] = $result['message'];
            }
            
            header('Location: /panel'); // Redirigimos al panel del usuario
        } else {
            $_SESSION['error'] = $result['message'];
            header('Location: /reservar');
        }
        exit;
    }
}
