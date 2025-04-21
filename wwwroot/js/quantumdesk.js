/**
 * QuantumDesk - Scripts communs
 * Ce fichier contient les fonctionnalités JavaScript communes utilisées dans toute l'application
 * Version: 1.0.0
 */

// Fonction d'initialisation principale - s'exécute lorsque le DOM est prêt
document.addEventListener('DOMContentLoaded', function() {
    console.log('🚀 QuantumDesk initialized');
    initializeNavigation();
    initializeComponents();
    setupThemePreference();
    initializeTooltips();
    initializeNotifications();
    autoResizeTextareas();
    setupCopyButtons();
    setupDateTimeFormatting();
    initDragAndDropZones();
});

/**
 * Initialise les fonctionnalités de navigation
 */
function initializeNavigation() {
    // Active le menu de navigation actif basé sur la page courante
    const currentPath = window.location.pathname;
    const navLinks = document.querySelectorAll('.quantum-nav-link');
    
    navLinks.forEach(link => {
        const href = link.getAttribute('href');
        if (href && currentPath.includes(href) && href !== '/') {
            link.classList.add('active');
        } else if (href === '/' && currentPath === '/') {
            link.classList.add('active');
        }
    });
    
    // Gestion des menus déroulants
    const dropdownToggles = document.querySelectorAll('.quantum-dropdown-toggle');
    dropdownToggles.forEach(toggle => {
        toggle.addEventListener('click', function(e) {
            e.preventDefault();
            e.stopPropagation();
            
            const dropdown = this.nextElementSibling;
            const isOpen = dropdown.classList.contains('show');
            
            // Ferme tous les dropdowns ouverts
            document.querySelectorAll('.quantum-dropdown-menu.show').forEach(menu => {
                if (menu !== dropdown) {
                    menu.classList.remove('show');
                }
            });
            
            // Toggle le dropdown actuel
            dropdown.classList.toggle('show');
            
            // Ajoute un événement de clic sur le document pour fermer les dropdowns
            if (!isOpen) {
                setTimeout(() => {
                    document.addEventListener('click', closeDropdowns);
                }, 10);
            }
        });
    });
    
    function closeDropdowns() {
        document.querySelectorAll('.quantum-dropdown-menu.show').forEach(menu => {
            menu.classList.remove('show');
        });
        document.removeEventListener('click', closeDropdowns);
    }
}

/**
 * Initialise les composants UI communs
 */
function initializeComponents() {
    // Initialiser les onglets
    const tabItems = document.querySelectorAll('.quantum-tab');
    tabItems.forEach(tab => {
        tab.addEventListener('click', function() {
            const targetId = this.getAttribute('data-target');
            const tabContainer = this.closest('.quantum-tabs-container');
            
            // Réinitialise tous les onglets et panneaux
            tabContainer.querySelectorAll('.quantum-tab').forEach(t => t.classList.remove('active'));
            tabContainer.querySelectorAll('.quantum-tab-pane').forEach(p => p.classList.remove('active'));
            
            // Active l'onglet et le panneau sélectionnés
            this.classList.add('active');
            if (targetId) {
                const targetPane = document.getElementById(targetId);
                if (targetPane) {
                    targetPane.classList.add('active');
                }
            }
        });
    });
    
    // Animation pour les cartes
    const cards = document.querySelectorAll('.quantum-card, .quantum-widget');
    cards.forEach(card => {
        card.addEventListener('mouseenter', function() {
            this.classList.add('quantum-animate-lift');
        });
        
        card.addEventListener('mouseleave', function() {
            this.classList.remove('quantum-animate-lift');
        });
    });
    
    // Initialiser les boutons de collapsible
    const collapsibles = document.querySelectorAll('[data-toggle="collapse"]');
    collapsibles.forEach(button => {
        button.addEventListener('click', function() {
            const targetId = this.getAttribute('data-target');
            const target = document.querySelector(targetId);
            
            if (target) {
                target.classList.toggle('show');
                
                // Toggle l'icône si elle existe
                const icon = this.querySelector('.collapse-icon');
                if (icon) {
                    icon.classList.toggle('rotated');
                }
            }
        });
    });
}

/**
 * Gère les préférences de thème (mode clair/sombre)
 */
function setupThemePreference() {
    const themeToggle = document.getElementById('theme-toggle');
    if (!themeToggle) return;
    
    // Vérifie la préférence sauvegardée ou utilise la préférence du système
    const savedTheme = localStorage.getItem('quantumdesk-theme');
    const prefersDarkMode = window.matchMedia('(prefers-color-scheme: dark)').matches;
    
    if (savedTheme === 'dark' || (!savedTheme && prefersDarkMode)) {
        document.body.classList.add('dark-mode');
        themeToggle.checked = true;
    }
    
    // Change le thème quand l'utilisateur clique sur le toggle
    themeToggle.addEventListener('change', function() {
        if (this.checked) {
            document.body.classList.add('dark-mode');
            localStorage.setItem('quantumdesk-theme', 'dark');
        } else {
            document.body.classList.remove('dark-mode');
            localStorage.setItem('quantumdesk-theme', 'light');
        }
    });
}

/**
 * Initialise les tooltips
 */
function initializeTooltips() {
    const tooltips = document.querySelectorAll('.quantum-tooltip');
    tooltips.forEach(tooltip => {
        const content = tooltip.getAttribute('data-tooltip');
        if (content) {
            const tooltipElement = document.createElement('span');
            tooltipElement.className = 'quantum-tooltip-text';
            tooltipElement.textContent = content;
            tooltip.appendChild(tooltipElement);
        }
    });
}

/**
 * Gère les notifications du système
 */
function initializeNotifications() {
    // Compteur pour le badge de notification
    const notificationBadge = document.querySelector('.notification-badge');
    const notificationItems = document.querySelectorAll('.quantum-notification');
    
    if (notificationBadge && notificationItems.length > 0) {
        notificationBadge.textContent = notificationItems.length;
        notificationBadge.classList.remove('hidden');
    }
    
    // Fermeture des notifications
    const closeButtons = document.querySelectorAll('.quantum-notification-close');
    closeButtons.forEach(button => {
        button.addEventListener('click', function() {
            const notification = this.closest('.quantum-notification');
            
            // Animation de sortie
            notification.style.opacity = '0';
            notification.style.transform = 'translateX(100%)';
            
            // Supprime la notification après l'animation
            setTimeout(() => {
                notification.remove();
                
                // Met à jour le compteur de notification
                const remainingNotifications = document.querySelectorAll('.quantum-notification').length;
                if (notificationBadge) {
                    if (remainingNotifications > 0) {
                        notificationBadge.textContent = remainingNotifications;
                    } else {
                        notificationBadge.classList.add('hidden');
                    }
                }
            }, 300);
        });
    });
}

/**
 * Redimensionne automatiquement les zones de texte
 */
function autoResizeTextareas() {
    const textareas = document.querySelectorAll('.quantum-auto-resize');
    
    function resize(textarea) {
        textarea.style.height = 'auto';
        textarea.style.height = textarea.scrollHeight + 'px';
    }
    
    textareas.forEach(textarea => {
        resize(textarea);
        
        textarea.addEventListener('input', function() {
            resize(this);
        });
        
        textarea.addEventListener('focus', function() {
            resize(this);
        });
    });
}

/**
 * Configure les boutons de copie pour les éléments de code
 */
function setupCopyButtons() {
    const codeBlocks = document.querySelectorAll('pre code');
    
    codeBlocks.forEach(code => {
        // Crée un bouton de copie
        const copyButton = document.createElement('button');
        copyButton.className = 'quantum-copy-button';
        copyButton.innerHTML = '<i class="fas fa-copy"></i>';
        copyButton.title = 'Copier dans le presse-papier';
        
        // Ajoute le bouton au bloc de code
        const pre = code.parentNode;
        pre.style.position = 'relative';
        pre.appendChild(copyButton);
        
        // Événement de clic pour copier le code
        copyButton.addEventListener('click', function() {
            const textToCopy = code.textContent;
            
            navigator.clipboard.writeText(textToCopy).then(() => {
                copyButton.innerHTML = '<i class="fas fa-check"></i>';
                copyButton.classList.add('copied');
                
                setTimeout(() => {
                    copyButton.innerHTML = '<i class="fas fa-copy"></i>';
                    copyButton.classList.remove('copied');
                }, 2000);
            }).catch(err => {
                console.error('Erreur lors de la copie:', err);
            });
        });
    });
}

/**
 * Formate les dates et heures
 */
function setupDateTimeFormatting() {
    const dateElements = document.querySelectorAll('.quantum-date');
    const timeAgoElements = document.querySelectorAll('.quantum-timeago');
    const currentDate = new Date();
    
    // Format de date standard
    dateElements.forEach(element => {
        const dateStr = element.getAttribute('data-date');
        if (dateStr) {
            const date = new Date(dateStr);
            element.textContent = formatDate(date);
        }
    });
    
    // Format relatif (il y a...)
    timeAgoElements.forEach(element => {
        const dateStr = element.getAttribute('data-date');
        if (dateStr) {
            const date = new Date(dateStr);
            element.textContent = getTimeAgo(date, currentDate);
        }
    });
    
    function formatDate(date) {
        return new Intl.DateTimeFormat(navigator.language, {
            year: 'numeric',
            month: 'short',
            day: 'numeric',
            hour: '2-digit',
            minute: '2-digit'
        }).format(date);
    }
    
    function getTimeAgo(date, currentDate) {
        const seconds = Math.floor((currentDate - date) / 1000);
        
        let interval = Math.floor(seconds / 31536000);
        if (interval > 1) return `il y a ${interval} ans`;
        if (interval === 1) return `il y a 1 an`;
        
        interval = Math.floor(seconds / 2592000);
        if (interval > 1) return `il y a ${interval} mois`;
        if (interval === 1) return `il y a 1 mois`;
        
        interval = Math.floor(seconds / 86400);
        if (interval > 1) return `il y a ${interval} jours`;
        if (interval === 1) return `il y a 1 jour`;
        
        interval = Math.floor(seconds / 3600);
        if (interval > 1) return `il y a ${interval} heures`;
        if (interval === 1) return `il y a 1 heure`;
        
        interval = Math.floor(seconds / 60);
        if (interval > 1) return `il y a ${interval} minutes`;
        if (interval === 1) return `il y a 1 minute`;
        
        return `il y a quelques secondes`;
    }
}

/**
 * Initialise les zones de glisser-déposer pour les fichiers
 */
function initDragAndDropZones() {
    const dropZones = document.querySelectorAll('.quantum-dropzone');
    
    dropZones.forEach(zone => {
        const input = zone.querySelector('input[type="file"]');
        const preview = zone.querySelector('.quantum-dropzone-preview');
        
        // Événements pour le drag & drop
        zone.addEventListener('dragover', function(e) {
            e.preventDefault();
            this.classList.add('quantum-dropzone-hover');
        });
        
        zone.addEventListener('dragleave', function() {
            this.classList.remove('quantum-dropzone-hover');
        });
        
        zone.addEventListener('drop', function(e) {
            e.preventDefault();
            this.classList.remove('quantum-dropzone-hover');
            
            if (e.dataTransfer.files.length > 0 && input) {
                input.files = e.dataTransfer.files;
                showPreview(e.dataTransfer.files);
                
                // Déclenche l'événement change pour activer les validations
                const event = new Event('change', { bubbles: true });
                input.dispatchEvent(event);
            }
        });
        
        // Événement de clic sur la zone
        zone.addEventListener('click', function() {
            if (input) {
                input.click();
            }
        });
        
        // Événement de changement sur l'input file
        if (input) {
            input.addEventListener('change', function() {
                showPreview(this.files);
            });
        }
        
        // Affiche l'aperçu des fichiers
        function showPreview(files) {
            if (!preview) return;
            
            preview.innerHTML = '';
            
            Array.from(files).forEach(file => {
                const item = document.createElement('div');
                item.className = 'quantum-dropzone-item';
                
                // Détermine le type d'icône basé sur le type de fichier
                let iconClass = 'fa-file';
                if (file.type.startsWith('image/')) {
                    iconClass = 'fa-file-image';
                } else if (file.type.startsWith('video/')) {
                    iconClass = 'fa-file-video';
                } else if (file.type.startsWith('audio/')) {
                    iconClass = 'fa-file-audio';
                } else if (file.type === 'application/pdf') {
                    iconClass = 'fa-file-pdf';
                } else if (file.type.includes('spreadsheet') || file.name.endsWith('.xlsx') || file.name.endsWith('.xls')) {
                    iconClass = 'fa-file-excel';
                } else if (file.type.includes('document') || file.name.endsWith('.docx') || file.name.endsWith('.doc')) {
                    iconClass = 'fa-file-word';
                }
                
                item.innerHTML = `
                    <div class="quantum-dropzone-icon">
                        <i class="fas ${iconClass}"></i>
                    </div>
                    <div class="quantum-dropzone-info">
                        <span class="quantum-dropzone-filename">${file.name}</span>
                        <span class="quantum-dropzone-filesize">${formatFileSize(file.size)}</span>
                    </div>
                    <button type="button" class="quantum-dropzone-remove">
                        <i class="fas fa-times"></i>
                    </button>
                `;
                
                preview.appendChild(item);
                
                // Événement pour supprimer le fichier
                const removeButton = item.querySelector('.quantum-dropzone-remove');
                removeButton.addEventListener('click', function(e) {
                    e.stopPropagation();
                    item.remove();
                    
                    // Réinitialiser l'input file est complexe, donc recréer un nouvel input
                    const newInput = document.createElement('input');
                    newInput.type = 'file';
                    newInput.name = input.name;
                    newInput.id = input.id;
                    newInput.className = input.className;
                    newInput.multiple = input.multiple;
                    newInput.accept = input.accept;
                    
                    input.parentNode.replaceChild(newInput, input);
                    input = newInput;
                    
                    // Réattacher l'événement de changement
                    input.addEventListener('change', function() {
                        showPreview(this.files);
                    });
                });
            });
            
            zone.classList.add('has-files');
        }
        
        function formatFileSize(bytes) {
            if (bytes === 0) return '0 Bytes';
            
            const k = 1024;
            const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
            const i = Math.floor(Math.log(bytes) / Math.log(k));
            
            return parseFloat((bytes / Math.pow(k, i)).toFixed(2)) + ' ' + sizes[i];
        }
    });
}