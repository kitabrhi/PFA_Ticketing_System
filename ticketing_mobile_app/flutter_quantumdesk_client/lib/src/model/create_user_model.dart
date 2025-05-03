//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:built_collection/built_collection.dart';
import 'package:openapi/src/model/user.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'create_user_model.g.dart';

/// CreateUserModel
///
/// Properties:
/// * [user] 
/// * [password] 
/// * [selectedRoles] 
@BuiltValue()
abstract class CreateUserModel implements Built<CreateUserModel, CreateUserModelBuilder> {
  @BuiltValueField(wireName: r'user')
  User? get user;

  @BuiltValueField(wireName: r'password')
  String? get password;

  @BuiltValueField(wireName: r'selectedRoles')
  BuiltList<String>? get selectedRoles;

  CreateUserModel._();

  factory CreateUserModel([void updates(CreateUserModelBuilder b)]) = _$CreateUserModel;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(CreateUserModelBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<CreateUserModel> get serializer => _$CreateUserModelSerializer();
}

class _$CreateUserModelSerializer implements PrimitiveSerializer<CreateUserModel> {
  @override
  final Iterable<Type> types = const [CreateUserModel, _$CreateUserModel];

  @override
  final String wireName = r'CreateUserModel';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    CreateUserModel object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.user != null) {
      yield r'user';
      yield serializers.serialize(
        object.user,
        specifiedType: const FullType(User),
      );
    }
    if (object.password != null) {
      yield r'password';
      yield serializers.serialize(
        object.password,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.selectedRoles != null) {
      yield r'selectedRoles';
      yield serializers.serialize(
        object.selectedRoles,
        specifiedType: const FullType.nullable(BuiltList, [FullType(String)]),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    CreateUserModel object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required CreateUserModelBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'user':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(User),
          ) as User;
          result.user.replace(valueDes);
          break;
        case r'password':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.password = valueDes;
          break;
        case r'selectedRoles':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(String)]),
          ) as BuiltList<String>?;
          if (valueDes == null) continue;
          result.selectedRoles.replace(valueDes);
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  CreateUserModel deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = CreateUserModelBuilder();
    final serializedList = (serialized as Iterable<Object?>).toList();
    final unhandled = <Object?>[];
    _deserializeProperties(
      serializers,
      serialized,
      specifiedType: specifiedType,
      serializedList: serializedList,
      unhandled: unhandled,
      result: result,
    );
    return result.build();
  }
}

