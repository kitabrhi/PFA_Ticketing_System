// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'create_user_model.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$CreateUserModel extends CreateUserModel {
  @override
  final User? user;
  @override
  final String? password;
  @override
  final BuiltList<String>? selectedRoles;

  factory _$CreateUserModel([void Function(CreateUserModelBuilder)? updates]) =>
      (new CreateUserModelBuilder()..update(updates))._build();

  _$CreateUserModel._({this.user, this.password, this.selectedRoles})
      : super._();

  @override
  CreateUserModel rebuild(void Function(CreateUserModelBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  CreateUserModelBuilder toBuilder() =>
      new CreateUserModelBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is CreateUserModel &&
        user == other.user &&
        password == other.password &&
        selectedRoles == other.selectedRoles;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, user.hashCode);
    _$hash = $jc(_$hash, password.hashCode);
    _$hash = $jc(_$hash, selectedRoles.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'CreateUserModel')
          ..add('user', user)
          ..add('password', password)
          ..add('selectedRoles', selectedRoles))
        .toString();
  }
}

class CreateUserModelBuilder
    implements Builder<CreateUserModel, CreateUserModelBuilder> {
  _$CreateUserModel? _$v;

  UserBuilder? _user;
  UserBuilder get user => _$this._user ??= new UserBuilder();
  set user(UserBuilder? user) => _$this._user = user;

  String? _password;
  String? get password => _$this._password;
  set password(String? password) => _$this._password = password;

  ListBuilder<String>? _selectedRoles;
  ListBuilder<String> get selectedRoles =>
      _$this._selectedRoles ??= new ListBuilder<String>();
  set selectedRoles(ListBuilder<String>? selectedRoles) =>
      _$this._selectedRoles = selectedRoles;

  CreateUserModelBuilder() {
    CreateUserModel._defaults(this);
  }

  CreateUserModelBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _user = $v.user?.toBuilder();
      _password = $v.password;
      _selectedRoles = $v.selectedRoles?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(CreateUserModel other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$CreateUserModel;
  }

  @override
  void update(void Function(CreateUserModelBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  CreateUserModel build() => _build();

  _$CreateUserModel _build() {
    _$CreateUserModel _$result;
    try {
      _$result = _$v ??
          new _$CreateUserModel._(
            user: _user?.build(),
            password: password,
            selectedRoles: _selectedRoles?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'user';
        _user?.build();

        _$failedField = 'selectedRoles';
        _selectedRoles?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'CreateUserModel', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
