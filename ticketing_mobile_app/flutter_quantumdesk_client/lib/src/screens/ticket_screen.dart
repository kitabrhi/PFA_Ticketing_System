import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';


class TicketScreen extends StatefulWidget {
  const TicketScreen({super.key});

  @override
  State<TicketScreen> createState() => _TicketScreenState();
}

class _TicketScreenState extends State<TicketScreen> {
  final List<Map<String, String>> tickets = [];
  final _formKey = GlobalKey<FormState>();

  String title = '';
  String category = '';
  String priority = '';
  String description = '';
  String assignTo = '';

  final List<String> categories = ['Bug', 'Feature', 'Support'];
  final List<String> priorities = ['Low', 'Normal', 'High', 'Urgent'];
  final List<String> users = ['Admin', 'Alice', 'Bob', 'Charlie'];

  void _addTicket() {
    if (_formKey.currentState!.validate()) {
      setState(() {
        tickets.add({
          'id': (tickets.length + 1).toString(),
          'title': title,
          'category': category,
          'priority': priority,
          'status': 'Open',
          'createdBy': 'Admin',
          'createdDate': DateTime.now().toString().split(" ")[0],
          'assignTo': assignTo,
        });
      });
      Navigator.pop(context);
    }
  }

  void _showCreateTicketForm() {
    showModalBottomSheet(
      context: context,
      isScrollControlled: true,
      backgroundColor: Colors.white,
      shape: const RoundedRectangleBorder(
        borderRadius: BorderRadius.vertical(top: Radius.circular(20)),
      ),
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
                    'Create New Ticket',
                    style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                  ),
                ),
                const SizedBox(height: 20),
                TextFormField(
                  decoration: const InputDecoration(labelText: 'Title'),
                  validator: (val) => val!.isEmpty ? 'Required' : null,
                  onChanged: (val) => title = val,
                ),
                const SizedBox(height: 12),
                DropdownButtonFormField<String>(
                  decoration: const InputDecoration(labelText: 'Category'),
                  items: categories.map((cat) {
                    return DropdownMenuItem(value: cat, child: Text(cat));
                  }).toList(),
                  onChanged: (val) => category = val ?? '',
                  validator: (val) =>
                      val == null || val.isEmpty ? 'Please select a category' : null,
                ),
                const SizedBox(height: 12),
                DropdownButtonFormField<String>(
                  decoration: const InputDecoration(labelText: 'Priority'),
                  items: priorities.map((prio) {
                    return DropdownMenuItem(value: prio, child: Text(prio));
                  }).toList(),
                  onChanged: (val) => priority = val ?? '',
                  validator: (val) =>
                      val == null || val.isEmpty ? 'Please select a priority' : null,
                ),
                const SizedBox(height: 12),
                TextFormField(
                  maxLines: 3,
                  decoration: const InputDecoration(labelText: 'Description'),
                  onChanged: (val) => description = val,
                ),
                const SizedBox(height: 12),
                DropdownButtonFormField<String>(
                  decoration: const InputDecoration(labelText: 'Assign To'),
                  items: users.map((user) {
                    return DropdownMenuItem(value: user, child: Text(user));
                  }).toList(),
                  onChanged: (val) => assignTo = val ?? '',
                  validator: (val) =>
                      val == null || val.isEmpty ? 'Please select a user' : null,
                ),
                const SizedBox(height: 20),
                SizedBox(
                  width: double.infinity,
                  child: ElevatedButton(
                    onPressed: _addTicket,
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Colors.black,
                      padding: const EdgeInsets.symmetric(vertical: 14),
                      shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(12)),
                    ),
                    child: const Text(
                      'Submit',
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

  Widget buildTicketCard(Map<String, String> ticket) {
  return Card(
    elevation: 4,
    margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 10),
    shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
    child: Padding(
      padding: const EdgeInsets.all(14.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          // 🔷 Header avec actions
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text(
                "#${ticket['id']} - ${ticket['title']}",
                style: const TextStyle(
                    fontSize: 16, fontWeight: FontWeight.bold),
              ),
              Row(
                children: [
                  IconButton(
                    tooltip: 'Edit',
                    icon: const FaIcon(FontAwesomeIcons.penToSquare,
                        color: Colors.teal),
                    onPressed: () {
                      // TODO: implement edit
                    },
                  ),
                  IconButton(
                    tooltip: 'Delete',
                    icon: const FaIcon(FontAwesomeIcons.trashCan,
                        color: Colors.redAccent),
                    onPressed: () {
                      setState(() => tickets.remove(ticket));
                    },
                  ),
                ],
              )
            ],
          ),

          const SizedBox(height: 8),
          Wrap(
            spacing: 10,
            runSpacing: 4,
            children: [
              Chip(
                label: Text("📂 ${ticket['category']}"),
                backgroundColor: Colors.grey.shade100,
              ),
              Chip(
                label: Text("🚨 ${ticket['priority']}"),
                backgroundColor: Colors.grey.shade100,
              ),
              Chip(
                label: Text("📌 ${ticket['status']}"),
                backgroundColor: Colors.grey.shade100,
              ),
              Chip(
                label: Text("👤 ${ticket['createdBy']}"),
                backgroundColor: Colors.grey.shade100,
              ),
              Chip(
                label: Text("📅 ${ticket['createdDate']}"),
                backgroundColor: Colors.grey.shade100,
              ),
              Chip(
                label: Text("➡️ ${ticket['assignTo']}"),
                backgroundColor: Colors.grey.shade100,
              ),
            ],
          ),
        ],
      ),
    ),
  );
}


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Tickets'),
        actions: [
          IconButton(
            icon: const Icon(Icons.add),
            onPressed: _showCreateTicketForm,
          ),
        ],
        backgroundColor: Colors.white,
        foregroundColor: Colors.black,
        elevation: 1,
      ),
      body: tickets.isEmpty
          ? const Center(child: Text('No tickets created yet.'))
          : ListView.builder(
              itemCount: tickets.length,
              itemBuilder: (context, index) =>
                  buildTicketCard(tickets[index]),
            ),
    );
  }
}
