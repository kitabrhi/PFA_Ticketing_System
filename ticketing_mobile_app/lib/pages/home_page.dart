import 'package:flutter/material.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  final List<Map<String, String>> dummyTickets = const [
    {
      "title": "Connexion impossible",
      "status": "Open",
      "priority": "High"
    },
    {
      "title": "Erreur 500 sur le serveur",
      "status": "In Progress",
      "priority": "Critical"
    },
    {
      "title": "Changement de mot de passe",
      "status": "Resolved",
      "priority": "Low"
    },
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("🎫 Ticketing System"),
        backgroundColor: Colors.indigo,
        centerTitle: true,
      ),
      body: ListView.builder(
        itemCount: dummyTickets.length,
        itemBuilder: (context, index) {
          final ticket = dummyTickets[index];
          return Card(
            margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
            child: ListTile(
              leading: const Icon(Icons.bug_report, color: Colors.indigo),
              title: Text(ticket["title"] ?? ""),
              subtitle: Text("Statut: ${ticket["status"]} | Priorité: ${ticket["priority"]}"),
              trailing: const Icon(Icons.arrow_forward_ios),
              onTap: () {
                ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(content: Text("Ticket sélectionné: ${ticket["title"]}")),
                );
              },
            ),
          );
        },
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(content: Text("Créer un nouveau ticket")),
          );
        },
        child: const Icon(Icons.add),
        backgroundColor: Colors.indigo,
      ),
    );
  }
}
