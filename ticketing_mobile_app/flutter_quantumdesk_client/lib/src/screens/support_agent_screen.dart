import 'package:flutter/material.dart';

class SupportAgentScreen extends StatefulWidget {
  const SupportAgentScreen({super.key});

  @override
  State<SupportAgentScreen> createState() => _SupportAgentScreenState();
}

class _SupportAgentScreenState extends State<SupportAgentScreen> {
  final List<Map<String, String>> agents = [];

  final _formKey = GlobalKey<FormState>();

  String nom = '';
  String prenom = '';
  String email = '';
  String motDePasse = '';

  void _ajouterAgent() {
    if (_formKey.currentState!.validate()) {
      setState(() {
        agents.add({
          'nom': nom,
          'prenom': prenom,
          'email': email,
          'motDePasse': motDePasse,
        });
      });
      Navigator.pop(context);
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Agent ajouté avec succès')),
      );
    }
  }

  void _afficherFormulaire() {
    showModalBottomSheet(
      context: context,
      isScrollControlled: true,
      shape: const RoundedRectangleBorder(
        borderRadius: BorderRadius.vertical(top: Radius.circular(24)),
      ),
      backgroundColor: Colors.white,
      builder: (context) => Padding(
        padding: EdgeInsets.only(
          top: 20,
          left: 20,
          right: 20,
          bottom: MediaQuery.of(context).viewInsets.bottom + 20,
        ),
        child: Form(
          key: _formKey,
          child: SingleChildScrollView(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                const Center(
                  child: Text(
                    'Ajouter un Support Agent',
                    style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                  ),
                ),
                const SizedBox(height: 20),
                TextFormField(
                  decoration: const InputDecoration(labelText: 'Nom'),
                  validator: (val) => val!.isEmpty ? 'Champ requis' : null,
                  onChanged: (val) => nom = val,
                ),
                const SizedBox(height: 12),
                TextFormField(
                  decoration: const InputDecoration(labelText: 'Prénom'),
                  validator: (val) => val!.isEmpty ? 'Champ requis' : null,
                  onChanged: (val) => prenom = val,
                ),
                const SizedBox(height: 12),
                TextFormField(
                  decoration: const InputDecoration(labelText: 'Email'),
                  keyboardType: TextInputType.emailAddress,
                  validator: (val) => val!.isEmpty ? 'Champ requis' : null,
                  onChanged: (val) => email = val,
                ),
                const SizedBox(height: 12),
                TextFormField(
                  decoration: const InputDecoration(labelText: 'Mot de passe'),
                  obscureText: true,
                  validator: (val) => val!.isEmpty ? 'Champ requis' : null,
                  onChanged: (val) => motDePasse = val,
                ),
                const SizedBox(height: 20),
                SizedBox(
                  width: double.infinity,
                  child: ElevatedButton(
                    onPressed: _ajouterAgent,
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Colors.black,
                      padding: const EdgeInsets.symmetric(vertical: 14),
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(12),
                      ),
                    ),
                    child: const Text(
                      'Ajouter',
                      style: TextStyle(color: Colors.white),
                    ),
                  ),
                )
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget buildAgentCard(Map<String, String> agent) {
    return Card(
      margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(14)),
      elevation: 4,
      child: ListTile(
        title: Text("${agent['prenom']} ${agent['nom']}"),
        subtitle: Text(agent['email']!),
        trailing: const Icon(Icons.person),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Support Agents'),
        actions: [
          IconButton(
            icon: const Icon(Icons.add),
            onPressed: _afficherFormulaire,
          ),
        ],
        backgroundColor: Colors.white,
        foregroundColor: Colors.black,
        elevation: 1,
      ),
      body: agents.isEmpty
          ? const Center(child: Text('Aucun agent ajouté.'))
          : ListView.builder(
              itemCount: agents.length,
              itemBuilder: (context, index) => buildAgentCard(agents[index]),
            ),
    );
  }
}
