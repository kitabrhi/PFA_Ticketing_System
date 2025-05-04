// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ticket_status.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

const TicketStatus _$number0 = const TicketStatus._('number0');
const TicketStatus _$number1 = const TicketStatus._('number1');
const TicketStatus _$number2 = const TicketStatus._('number2');
const TicketStatus _$number3 = const TicketStatus._('number3');

TicketStatus _$valueOf(String name) {
  switch (name) {
    case 'number0':
      return _$number0;
    case 'number1':
      return _$number1;
    case 'number2':
      return _$number2;
    case 'number3':
      return _$number3;
    default:
      throw new ArgumentError(name);
  }
}

final BuiltSet<TicketStatus> _$values =
    new BuiltSet<TicketStatus>(const <TicketStatus>[
  _$number0,
  _$number1,
  _$number2,
  _$number3,
]);

class _$TicketStatusMeta {
  const _$TicketStatusMeta();
  TicketStatus get number0 => _$number0;
  TicketStatus get number1 => _$number1;
  TicketStatus get number2 => _$number2;
  TicketStatus get number3 => _$number3;
  TicketStatus valueOf(String name) => _$valueOf(name);
  BuiltSet<TicketStatus> get values => _$values;
}

abstract class _$TicketStatusMixin {
  // ignore: non_constant_identifier_names
  _$TicketStatusMeta get TicketStatus => const _$TicketStatusMeta();
}

Serializer<TicketStatus> _$ticketStatusSerializer =
    new _$TicketStatusSerializer();

class _$TicketStatusSerializer implements PrimitiveSerializer<TicketStatus> {
  static const Map<String, Object> _toWire = const <String, Object>{
    'number0': 0,
    'number1': 1,
    'number2': 2,
    'number3': 3,
  };
  static const Map<Object, String> _fromWire = const <Object, String>{
    0: 'number0',
    1: 'number1',
    2: 'number2',
    3: 'number3',
  };

  @override
  final Iterable<Type> types = const <Type>[TicketStatus];
  @override
  final String wireName = 'TicketStatus';

  @override
  Object serialize(Serializers serializers, TicketStatus object,
          {FullType specifiedType = FullType.unspecified}) =>
      _toWire[object.name] ?? object.name;

  @override
  TicketStatus deserialize(Serializers serializers, Object serialized,
          {FullType specifiedType = FullType.unspecified}) =>
      TicketStatus.valueOf(
          _fromWire[serialized] ?? (serialized is String ? serialized : ''));
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
