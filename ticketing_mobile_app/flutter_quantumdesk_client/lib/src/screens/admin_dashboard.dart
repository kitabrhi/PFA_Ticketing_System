import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:openapi/src/screens/support_agent_screen.dart';
import 'package:openapi/src/screens/ticket_screen.dart';
import 'equipe_screen.dart'; // Ton écran Équipe

class AdminDashboardScreen extends StatefulWidget {
  const AdminDashboardScreen({super.key});

  @override
  State<AdminDashboardScreen> createState() => _AdminDashboardScreenState();
}

class _AdminDashboardScreenState extends State<AdminDashboardScreen> {
  int currentIndex = 0;

  final List<IconData> icons = [
    FontAwesomeIcons.house,
    FontAwesomeIcons.peopleGroup,
    FontAwesomeIcons.ticket,
    FontAwesomeIcons.userPlus,
    FontAwesomeIcons.userCircle,
  ];

  final List<String> labels = [
    'Home',
    'Équipe',
    'Tickets',
    'SupportAgent',
    'Profil',
  ];

  final List<Widget> screens = [
    const HomeContent(),
    const EquipeScreen(),
    const TicketScreen(), // À remplacer plus tard
    const SupportAgentScreen(),
    Center(child: Text('Profil')),
  ];

  void handleNavigation(int index) {
    setState(() => currentIndex = index);
  }

  @override
  Widget build(BuildContext context) {
    final bool showHeader = currentIndex == 0;

    return Scaffold(
      backgroundColor: Colors.white,
      body: Column(
        children: [
          if (showHeader)
            Container(
              height: 120,
              padding: const EdgeInsets.symmetric(horizontal: 20),
              decoration: const BoxDecoration(
                gradient: LinearGradient(
                  colors: [Color(0xFF00B894), Color(0xFF00CEC9)],
                  begin: Alignment.topLeft,
                  end: Alignment.bottomRight,
                ),
                borderRadius: BorderRadius.only(
                  bottomLeft: Radius.circular(30),
                  bottomRight: Radius.circular(30),
                ),
              ),
              child: SafeArea(
                child: Row(
                  children: [
                    const CircleAvatar(
                      radius: 26,
                      backgroundImage: AssetImage('assets/images/intro1.png'),
                    ),
                    const SizedBox(width: 12),
                    const Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Text(
                          'Admin QuantumDesk',
                          style: TextStyle(
                            color: Colors.white,
                            fontSize: 16,
                            fontWeight: FontWeight.w600,
                          ),
                        ),
                        Text(
                          'admin@quantum.com',
                          style: TextStyle(
                            color: Colors.white70,
                            fontSize: 12,
                          ),
                        ),
                      ],
                    ),
                    const Spacer(),
                    IconButton(
                      icon: const Icon(Icons.notifications, color: Colors.white, size: 26),
                      onPressed: () {},
                    )
                  ],
                ),
              ),
            ),
          if (showHeader) const SizedBox(height: 20),

          // 🧩 Écran courant selon index
          Expanded(child: screens[currentIndex]),
        ],
      ),

      // ⬇️ Barre de navigation bas
      bottomNavigationBar: Container(
        decoration: const BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.only(
            topLeft: Radius.circular(25),
            topRight: Radius.circular(25),
          ),
          boxShadow: [
            BoxShadow(
              color: Colors.black12,
              blurRadius: 10,
              offset: Offset(0, -1),
            ),
          ],
        ),
        padding: const EdgeInsets.symmetric(vertical: 12, horizontal: 8),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: List.generate(icons.length, (index) {
            final isSelected = index == currentIndex;
            return GestureDetector(
              onTap: () => handleNavigation(index),
              child: Column(
                mainAxisSize: MainAxisSize.min,
                children: [
                  Container(
                    padding: const EdgeInsets.all(10),
                    decoration: BoxDecoration(
                      color: isSelected ? Colors.black : Colors.transparent,
                      shape: BoxShape.circle,
                    ),
                    child: FaIcon(
                      icons[index],
                      color: isSelected ? Colors.white : Colors.black87,
                      size: 20,
                    ),
                  ),
                  const SizedBox(height: 4),
                  Text(
                    labels[index],
                    style: TextStyle(
                      fontSize: 12,
                      fontWeight: isSelected ? FontWeight.bold : FontWeight.normal,
                      color: isSelected ? Colors.black : Colors.black54,
                    ),
                  ),
                ],
              ),
            );
          }),
        ),
      ),
    );
  }
}

// ✅ Widget Home (accueil)
class HomeContent extends StatelessWidget {
  const HomeContent({super.key});

  @override
  Widget build(BuildContext context) {
    return const Center(
      child: Text(
        'Bienvenue, Admin !',
        style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.w500,
          color: Colors.black87,
        ),
      ),
    );
  }
}
