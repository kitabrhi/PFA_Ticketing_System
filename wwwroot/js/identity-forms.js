/**
 * QuantumDesk - Scripts pour les formulaires d'identité
 * Ce fichier contient les fonctionnalités spécifiques aux pages d'authentification
 * (Login, Register, Reset Password, etc.)
 * 
 * Version: 1.0.0
 */

document.addEventListener('DOMContentLoaded', function() {
    console.log('🔐 QuantumDesk Identity Forms initialized');
    initPasswordStrengthMeter();
    initFormValidation();
    initShowHidePassword();
    initFormSubmitAnimation();
    initMaterialInputs();
    initSmoothScrolling();
    setupRememberMe();
    setupExternalLogin();
    initParticlesBackground();
});

/**
 * Initialise l'indicateur de force du mot de passe
 */
function initPasswordStrengthMeter() {
    const passwordInput = document.querySelector('input[type="password"][name*="Password"]:not([name*="Confirm"])');
    const strengthMeter = document.querySelector('.password-strength-meter');
    const strengthText = document.querySelector('.password-strength-text');
    
    if (!passwordInput || !strengthMeter) return;
    
    passwordInput.addEventListener('input', function() {
        const value = this.value;
        let strength = 0;
        let strengthClass = '';
        let strengthLabel = '';
        
        // Réinitialiser les classes
        strengthMeter.className = 'password-strength-meter';
        
        // Critères de force du mot de passe
        const hasLowerCase = /[a-z]/.test(value);
        const hasUpperCase = /[A-Z]/.test(value);
        const hasNumber = /\d/.test(value);
        const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(value);
        const isLongEnough = value.length >= 8;
        
        // Calcul du score
        if (value.length > 0) strength += 1; // Au moins un caractère
        if (value.length >= 6) strength += 1; // Au moins 6 caractères
        if (isLongEnough) strength += 1; // Au moins 8 caractères
        if (hasLowerCase && hasUpperCase) strength += 1; // Minuscules et majuscules
        if (hasNumber) strength += 1; // Au moins un chiffre
        if (hasSpecialChar) strength += 1; // Au moins un caractère spécial
        if (value.length >= 12) strength += 1; // Au moins 12 caractères
        
        // Déterminer la classe et le libellé basés sur la force
        switch (true) {
            case (strength === 0):
                strengthClass = '';
                strengthLabel = '';
                break;
            case (strength <= 2):
                strengthClass = 'password-weak';
                strengthLabel = 'Faible';
                break;
            case (strength <= 4):
                strengthClass = 'password-medium';
                strengthLabel = 'Moyen';
                break;
            case (strength <= 6):
                strengthClass = 'password-strong';
                strengthLabel = 'Fort';
                break;
            default:
                strengthClass = 'password-very-strong';
                strengthLabel = 'Très fort';
        }
        
        // Mettre à jour l'indicateur visuel
        strengthMeter.classList.add(strengthClass);
        
        // Mettre à jour le texte si l'élément existe
        if (strengthText) {
            strengthText.textContent = value.length > 0 ? strengthLabel : '';
            strengthText.className = 'password-strength-text';
            if (strengthClass) {
                strengthText.classList.add(strengthClass + '-text');
            }
        }
        
        // Animation subtile de l'indicateur
        strengthMeter.style.transition = 'none';
        strengthMeter.offsetHeight; // Force reflow
        strengthMeter.style.transition = 'all 0.3s ease';
    });
    
    // Déclencher l'événement pour initialiser l'indicateur si le champ a déjà une valeur
    if (passwordInput.value) {
        const event = new Event('input');
        passwordInput.dispatchEvent(event);
    }
}

/**
 * Validation avancée des formulaires
 */
function initFormValidation() {
    const forms = document.querySelectorAll('.identity-form');
    
    forms.forEach(form => {
        // Liste des champs avec validation en temps réel
        const fieldsToValidate = form.querySelectorAll('input[required], input[data-validate]');
        
        fieldsToValidate.forEach(field => {
            field.addEventListener('blur', function() {
                validateField(this);
            });
            
            field.addEventListener('input', function() {
                // Si le champ était déjà invalide, revalider à chaque frappe
                if (this.classList.contains('is-invalid')) {
                    validateField(this);
                }
            });
        });
        
        // Validation à la soumission
        form.addEventListener('submit', function(e) {
            let formValid = true;
            
            fieldsToValidate.forEach(field => {
                if (!validateField(field)) {
                    formValid = false;
                }
            });
            
            // Valider les mots de passe qui doivent correspondre
            const password = form.querySelector('input[name*="Password"]:not([name*="Confirm"])');
            const confirmPassword = form.querySelector('input[name*="ConfirmPassword"]');
            
            if (password && confirmPassword && password.value !== confirmPassword.value) {
                setFieldError(confirmPassword, 'Les mots de passe ne correspondent pas');
                formValid = false;
            }
            
            if (!formValid) {
                e.preventDefault();
                
                // Faire défiler jusqu'au premier champ avec erreur
                const firstError = form.querySelector('.is-invalid');
                if (firstError) {
                    firstError.focus();
                    firstError.scrollIntoView({ behavior: 'smooth', block: 'center' });
                }
            }
        });
    });
    
    function validateField(field) {
        // Réinitialiser l'état
        clearFieldError(field);
        
        // Vérifier si le champ est vide alors qu'il est requis
        if (field.hasAttribute('required') && !field.value.trim()) {
            setFieldError(field, 'Ce champ est requis');
            return false;
        }
        
        // Validation des emails
        if (field.type === 'email' && field.value) {
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailRegex.test(field.value)) {
                setFieldError(field, 'Veuillez entrer une adresse email valide');
                return false;
            }
        }
        
        // Validation personnalisée via attributs data-*
        if (field.dataset.minLength && field.value.length < parseInt(field.dataset.minLength)) {
            setFieldError(field, `Doit contenir au moins ${field.dataset.minLength} caractères`);
            return false;
        }
        
        if (field.dataset.pattern) {
            const pattern = new RegExp(field.dataset.pattern);
            if (!pattern.test(field.value)) {
                setFieldError(field, field.dataset.patternMessage || 'Format invalide');
                return false;
            }
        }
        
        // Validation réussie
        field.classList.add('is-valid');
        return true;
    }
    
    function setFieldError(field, message) {
        field.classList.remove('is-valid');
        field.classList.add('is-invalid');
        
        // Créer ou mettre à jour le message d'erreur
        let feedbackElement = field.nextElementSibling;
        if (!feedbackElement || !feedbackElement.classList.contains('invalid-feedback')) {
            feedbackElement = document.createElement('div');
            feedbackElement.className = 'invalid-feedback';
            field.insertAdjacentElement('afterend', feedbackElement);
        }
        
        feedbackElement.textContent = message;
    }
    
    function clearFieldError(field) {
        field.classList.remove('is-invalid', 'is-valid');
        
        // Supprimer le message d'erreur s'il existe
        const feedbackElement = field.nextElementSibling;
        if (feedbackElement && feedbackElement.classList.contains('invalid-feedback')) {
            feedbackElement.textContent = '';
        }
    }
}

/**
 * Ajoute la fonctionnalité pour afficher/masquer le mot de passe
 */
function initShowHidePassword() {
    const passwordFields = document.querySelectorAll('input[type="password"]');
    
    passwordFields.forEach(field => {
        // Créer le bouton pour afficher/masquer
        const toggleButton = document.createElement('button');
        toggleButton.type = 'button';
        toggleButton.className = 'password-toggle-btn';
        toggleButton.innerHTML = '<i class="fas fa-eye"></i>';
        toggleButton.title = 'Afficher le mot de passe';
        
        // Insérer le bouton après le champ
        field.parentNode.style.position = 'relative';
        field.parentNode.appendChild(toggleButton);
        
        // Positionner le bouton à l'intérieur du champ
        toggleButton.style.position = 'absolute';
        toggleButton.style.right = '10px';
        toggleButton.style.top = '50%';
        toggleButton.style.transform = 'translateY(-50%)';
        toggleButton.style.background = 'none';
        toggleButton.style.border = 'none';
        toggleButton.style.color = '#8da1b5';
        toggleButton.style.cursor = 'pointer';
        
        // Événement de clic pour basculer la visibilité
        toggleButton.addEventListener('click', function() {
            const type = field.getAttribute('type') === 'password' ? 'text' : 'password';
            field.setAttribute('type', type);
            
            // Changer l'icône
            const icon = this.querySelector('i');
            if (type === 'text') {
                icon.className = 'fas fa-eye-slash';
                this.title = 'Masquer le mot de passe';
            } else {
                icon.className = 'fas fa-eye';
                this.title = 'Afficher le mot de passe';
            }
            
            // Refocus le champ
            field.focus();
        });
    });
}

/**
 * Animation lors de la soumission du formulaire
 */
function initFormSubmitAnimation() {
    const forms = document.querySelectorAll('.identity-form');
    
    forms.forEach(form => {
        form.addEventListener('submit', function() {
            const submitButton = this.querySelector('button[type="submit"]');
            if (!submitButton) return;
            
            // Sauvegarder le texte original
            if (!submitButton.dataset.originalText) {
                submitButton.dataset.originalText = submitButton.innerHTML;
            }
            
            // Afficher l'animation de chargement
            submitButton.disabled = true;
            submitButton.innerHTML = '<span class="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span> Chargement...';
            
            // Ajouter une classe pour animation subtile
            submitButton.classList.add('submitting');
            
            // Réactive le bouton et restaure le texte en cas d'erreur de validation
            setTimeout(() => {
                if (form.querySelector('.is-invalid')) {
                    submitButton.disabled = false;
                    submitButton.innerHTML = submitButton.dataset.originalText;
                    submitButton.classList.remove('submitting');
                }
            }, 500);
        });
    });
}

/**
 * Initialise les effets de type Material Design pour les champs de formulaire
 */
function initMaterialInputs() {
    const materialInputs = document.querySelectorAll('.quantum-form-control');
    
    materialInputs.forEach(input => {
        // Animation initiale si le champ a déjà une valeur
        if (input.value) {
            input.parentNode.classList.add('has-value');
        }
        
        // Événements pour les animations
        input.addEventListener('focus', function() {
            this.parentNode.classList.add('focused');
        });
        
        input.addEventListener('blur', function() {
            this.parentNode.classList.remove('focused');
            if (this.value) {
                this.parentNode.classList.add('has-value');
            } else {
                this.parentNode.classList.remove('has-value');
            }
        });
        
        input.addEventListener('input', function() {
            if (this.value) {
                this.parentNode.classList.add('has-value');
            } else {
                this.parentNode.classList.remove('has-value');
            }
        });
    });
}

/**
 * Initialise le défilement fluide pour les ancres
 */
function initSmoothScrolling() {
    const anchorLinks = document.querySelectorAll('a[href^="#"]:not([href="#"])');
    
    anchorLinks.forEach(link => {
        link.addEventListener('click', function(e) {
            e.preventDefault();
            
            const targetId = this.getAttribute('href');
            const targetElement = document.querySelector(targetId);
            
            if (targetElement) {
                targetElement.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });
}

/**
 * Gestion du "Se souvenir de moi"
 */
function setupRememberMe() {
    const rememberMeCheckbox = document.querySelector('input[name*="RememberMe"]');
    if (!rememberMeCheckbox) return;
    
    // Vérifie si l'email a été sauvegardé précédemment
    const savedEmail = localStorage.getItem('quantumdesk-remembered-email');
    if (savedEmail) {
        const emailInput = document.querySelector('input[type="email"], input[name*="Email"]');
        if (emailInput) {
            emailInput.value = savedEmail;
            rememberMeCheckbox.checked = true;
            
            // Ajouter la classe pour l'animation du label
            if (emailInput.parentNode.classList.contains('form-floating')) {
                emailInput.parentNode.classList.add('has-value');
            }
        }
    }
    
    // Sauvegarde l'email à la soumission si "Se souvenir de moi" est coché
    const form = rememberMeCheckbox.closest('form');
    if (form) {
        form.addEventListener('submit', function() {
            const emailInput = this.querySelector('input[type="email"], input[name*="Email"]');
            
            if (emailInput && rememberMeCheckbox.checked) {
                localStorage.setItem('quantumdesk-remembered-email', emailInput.value);
            } else {
                localStorage.removeItem('quantumdesk-remembered-email');
            }
        });
    }
}

/**
 * Configuration des boutons de connexion externes
 */
function setupExternalLogin() {
    const externalButtons = document.querySelectorAll('.btn-external');
    
    externalButtons.forEach(button => {
        button.addEventListener('click', function() {
            // Ajouter une classe pour l'animation
            this.classList.add('external-login-clicked');
            
            // Sauvegarde la redirection dans le localStorage pour la reprendre après login
            const returnUrl = new URLSearchParams(window.location.search).get('returnUrl');
            if (returnUrl) {
                sessionStorage.setItem('quantumdesk-redirect', returnUrl);
            }
        });
    });
}

/**
 * Initialise un fond animé avec des particules pour les pages d'authentification
 */
function initParticlesBackground() {
    const particlesContainer = document.getElementById('particles-background');
    if (!particlesContainer) return;
    
    // Configuration des particules
    const particlesConfig = {
        particles: [],
        maxParticles: 50,
        colors: [
            'rgba(0, 167, 142, 0.2)',  // Turquoise
            'rgba(123, 104, 238, 0.2)', // Violet clair
            'rgba(26, 58, 95, 0.15)'    // Bleu profond
        ]
    };
    
    // Créer le canvas
    const canvas = document.createElement('canvas');
    canvas.width = particlesContainer.offsetWidth;
    canvas.height = particlesContainer.offsetHeight;
    particlesContainer.appendChild(canvas);
    
    const ctx = canvas.getContext('2d');
    
    // Initialiser les particules
    for (let i = 0; i < particlesConfig.maxParticles; i++) {
        particlesConfig.particles.push({
            x: Math.random() * canvas.width,
            y: Math.random() * canvas.height,
            radius: Math.random() * 3 + 1,
            color: particlesConfig.colors[Math.floor(Math.random() * particlesConfig.colors.length)],
            speedX: Math.random() * 0.5 - 0.25,
            speedY: Math.random() * 0.5 - 0.25,
            opacity: Math.random() * 0.5 + 0.5
        });
    }
    
    // Animation des particules
    function animate() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        
        particlesConfig.particles.forEach(particle => {
            // Déplacer la particule
            particle.x += particle.speedX;
            particle.y += particle.speedY;
            
            // Rebondir sur les bords
            if (particle.x < 0 || particle.x > canvas.width) {
                particle.speedX = -particle.speedX;
            }
            
            if (particle.y < 0 || particle.y > canvas.height) {
                particle.speedY = -particle.speedY;
            }
            
            // Dessiner la particule
            ctx.beginPath();
            ctx.arc(particle.x, particle.y, particle.radius, 0, Math.PI * 2);
            ctx.fillStyle = particle.color;
            ctx.globalAlpha = particle.opacity;
            ctx.fill();
        });
        
        requestAnimationFrame(animate);
    }
    
    // Démarrer l'animation
    animate();
    
    // Redimensionner le canvas en cas de redimensionnement de la fenêtre
    window.addEventListener('resize', function() {
        canvas.width = particlesContainer.offsetWidth;
        canvas.height = particlesContainer.offsetHeight;
    });
}

// Fonction d'animation pour les compteurs
function animateCounters() {
    const counters = document.querySelectorAll('.counter-animate');
    
    counters.forEach(counter => {
        const target = parseInt(counter.getAttribute('data-target'));
        const duration = 2000; // Durée de l'animation en ms
        const startTime = performance.now();
        
        function updateCounter(currentTime) {
            const elapsedTime = currentTime - startTime;
            const progress = Math.min(elapsedTime / duration, 1);
            
            // Fonction d'easing pour une animation plus naturelle
            const easeOutQuad = t => t * (2 - t);
            const easedProgress = easeOutQuad(progress);
            
            const currentValue = Math.floor(easedProgress * target);
            counter.textContent = currentValue.toLocaleString();
            
            if (progress < 1) {
                requestAnimationFrame(updateCounter);
            } else {
                counter.textContent = target.toLocaleString();
            }
        }
        
        requestAnimationFrame(updateCounter);
    });
}

// Démarrer l'animation des compteurs lorsque les éléments sont visibles
document.addEventListener('DOMContentLoaded', function() {
    // Observer les éléments pour déclencher l'animation quand ils sont visibles
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                if (entry.target.classList.contains('counter-animate')) {
                    animateCounters();
                }
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.2 });
    
    document.querySelectorAll('.counter-animate').forEach(counter => {
        observer.observe(counter);
    });
});