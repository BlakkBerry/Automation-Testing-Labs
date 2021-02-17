namespace GoogleDriveSerializerV2
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Deserialize
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("selfLink")]
        public Uri SelfLink { get; set; }

        [JsonProperty("nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonProperty("nextLink")]
        public Uri NextLink { get; set; }

        [JsonProperty("incompleteSearch")]
        public bool IncompleteSearch { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("kind")]
        public ItemKind Kind { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("selfLink")]
        public Uri SelfLink { get; set; }

        [JsonProperty("webContentLink", NullValueHandling = NullValueHandling.Ignore)]
        public Uri WebContentLink { get; set; }

        [JsonProperty("alternateLink")]
        public Uri AlternateLink { get; set; }

        [JsonProperty("embedLink")]
        public Uri EmbedLink { get; set; }

        [JsonProperty("iconLink")]
        public Uri IconLink { get; set; }

        [JsonProperty("hasThumbnail")]
        public bool HasThumbnail { get; set; }

        [JsonProperty("thumbnailLink", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ThumbnailLink { get; set; }

        [JsonProperty("thumbnailVersion")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ThumbnailVersion { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("mimeType")]
        public string MimeType { get; set; }

        [JsonProperty("labels")]
        public Labels Labels { get; set; }

        [JsonProperty("copyRequiresWriterPermission")]
        public bool CopyRequiresWriterPermission { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }

        [JsonProperty("modifiedByMeDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ModifiedByMeDate { get; set; }

        [JsonProperty("lastViewedByMeDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastViewedByMeDate { get; set; }

        [JsonProperty("markedViewedByMeDate")]
        public DateTimeOffset MarkedViewedByMeDate { get; set; }

        [JsonProperty("version")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Version { get; set; }

        [JsonProperty("parents")]
        public Parent[] Parents { get; set; }

        [JsonProperty("exportLinks", NullValueHandling = NullValueHandling.Ignore)]
        public ExportLinks ExportLinks { get; set; }

        [JsonProperty("userPermission")]
        public UserPermission UserPermission { get; set; }

        [JsonProperty("permissions")]
        public Permission[] Permissions { get; set; }

        [JsonProperty("permissionIds")]
        public string[] PermissionIds { get; set; }

        [JsonProperty("quotaBytesUsed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long QuotaBytesUsed { get; set; }

        [JsonProperty("ownerNames")]
        public string[] OwnerNames { get; set; }

        [JsonProperty("owners")]
        public LastModifyingUser[] Owners { get; set; }

        [JsonProperty("lastModifyingUserName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastModifyingUserName { get; set; }

        [JsonProperty("lastModifyingUser", NullValueHandling = NullValueHandling.Ignore)]
        public LastModifyingUser LastModifyingUser { get; set; }

        [JsonProperty("ownedByMe")]
        public bool OwnedByMe { get; set; }

        [JsonProperty("capabilities")]
        public Dictionary<string, bool> Capabilities { get; set; }

        [JsonProperty("editable")]
        public bool Editable { get; set; }

        [JsonProperty("canComment")]
        public bool CanComment { get; set; }

        [JsonProperty("canReadRevisions")]
        public bool CanReadRevisions { get; set; }

        [JsonProperty("shareable")]
        public bool Shareable { get; set; }

        [JsonProperty("copyable")]
        public bool Copyable { get; set; }

        [JsonProperty("writersCanShare")]
        public bool WritersCanShare { get; set; }

        [JsonProperty("shared")]
        public bool Shared { get; set; }

        [JsonProperty("explicitlyTrashed")]
        public bool ExplicitlyTrashed { get; set; }

        [JsonProperty("appDataContents")]
        public bool AppDataContents { get; set; }

        [JsonProperty("spaces")]
        public Space[] Spaces { get; set; }

        [JsonProperty("isAppAuthorized")]
        public bool IsAppAuthorized { get; set; }

        [JsonProperty("sharedWithMeDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? SharedWithMeDate { get; set; }

        [JsonProperty("folderColorRgb", NullValueHandling = NullValueHandling.Ignore)]
        public FolderColorRgb? FolderColorRgb { get; set; }

        [JsonProperty("downloadUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri DownloadUrl { get; set; }

        [JsonProperty("originalFilename", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalFilename { get; set; }

        [JsonProperty("fileExtension", NullValueHandling = NullValueHandling.Ignore)]
        public string FileExtension { get; set; }

        [JsonProperty("fullFileExtension", NullValueHandling = NullValueHandling.Ignore)]
        public string FullFileExtension { get; set; }

        [JsonProperty("md5Checksum", NullValueHandling = NullValueHandling.Ignore)]
        public string Md5Checksum { get; set; }

        [JsonProperty("fileSize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FileSize { get; set; }

        [JsonProperty("headRevisionId", NullValueHandling = NullValueHandling.Ignore)]
        public string HeadRevisionId { get; set; }

        [JsonProperty("imageMediaMetadata", NullValueHandling = NullValueHandling.Ignore)]
        public ImageMediaMetadata ImageMediaMetadata { get; set; }
    }

    public partial class ExportLinks
    {
        [JsonProperty("application/rtf", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ApplicationRtf { get; set; }

        [JsonProperty("application/vnd.oasis.opendocument.text", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ApplicationVndOasisOpendocumentText { get; set; }

        [JsonProperty("text/html", NullValueHandling = NullValueHandling.Ignore)]
        public Uri TextHtml { get; set; }

        [JsonProperty("application/pdf")]
        public Uri ApplicationPdf { get; set; }

        [JsonProperty("application/epub+zip", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ApplicationEpubZip { get; set; }

        [JsonProperty("application/zip", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ApplicationZip { get; set; }

        [JsonProperty("application/vnd.openxmlformats-officedocument.wordprocessingml.document", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ApplicationVndOpenxmlformatsOfficedocumentWordprocessingmlDocument { get; set; }

        [JsonProperty("text/plain", NullValueHandling = NullValueHandling.Ignore)]
        public Uri TextPlain { get; set; }

        [JsonProperty("application/x-vnd.oasis.opendocument.spreadsheet", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ApplicationXVndOasisOpendocumentSpreadsheet { get; set; }

        [JsonProperty("text/tab-separated-values", NullValueHandling = NullValueHandling.Ignore)]
        public Uri TextTabSeparatedValues { get; set; }

        [JsonProperty("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet { get; set; }

        [JsonProperty("text/csv", NullValueHandling = NullValueHandling.Ignore)]
        public Uri TextCsv { get; set; }

        [JsonProperty("application/vnd.oasis.opendocument.spreadsheet", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ApplicationVndOasisOpendocumentSpreadsheet { get; set; }

        [JsonProperty("application/vnd.oasis.opendocument.presentation", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ApplicationVndOasisOpendocumentPresentation { get; set; }

        [JsonProperty("application/vnd.openxmlformats-officedocument.presentationml.presentation", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ApplicationVndOpenxmlformatsOfficedocumentPresentationmlPresentation { get; set; }
    }

    public partial class ImageMediaMetadata
    {
        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("rotation")]
        public long Rotation { get; set; }
    }

    public partial class Labels
    {
        [JsonProperty("starred")]
        public bool Starred { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("trashed")]
        public bool Trashed { get; set; }

        [JsonProperty("restricted")]
        public bool Restricted { get; set; }

        [JsonProperty("viewed")]
        public bool Viewed { get; set; }

        [JsonProperty("modified")]
        public bool Modified { get; set; }
    }

    public partial class LastModifyingUser
    {
        [JsonProperty("kind")]
        public LastModifyingUserKind Kind { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("picture", NullValueHandling = NullValueHandling.Ignore)]
        public Picture Picture { get; set; }

        [JsonProperty("isAuthenticatedUser")]
        public bool IsAuthenticatedUser { get; set; }

        [JsonProperty("permissionId")]
        public string PermissionId { get; set; }

        [JsonProperty("emailAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; set; }
    }

    public partial class Picture
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Parent
    {
        [JsonProperty("kind")]
        public ParentKind Kind { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("selfLink")]
        public Uri SelfLink { get; set; }

        [JsonProperty("parentLink")]
        public Uri ParentLink { get; set; }

        [JsonProperty("isRoot")]
        public bool IsRoot { get; set; }
    }

    public partial class Permission
    {
        [JsonProperty("kind")]
        public PermissionKind Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("selfLink")]
        public Uri SelfLink { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("emailAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; set; }

        [JsonProperty("domain", NullValueHandling = NullValueHandling.Ignore)]
        public Domain? Domain { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("photoLink", NullValueHandling = NullValueHandling.Ignore)]
        public Uri PhotoLink { get; set; }

        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; set; }

        [JsonProperty("withLink", NullValueHandling = NullValueHandling.Ignore)]
        public bool? WithLink { get; set; }

        [JsonProperty("additionalRoles", NullValueHandling = NullValueHandling.Ignore)]
        public string[] AdditionalRoles { get; set; }
    }

    public partial class UserPermission
    {
        [JsonProperty("kind")]
        public PermissionKind Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("selfLink")]
        public Uri SelfLink { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("additionalRoles", NullValueHandling = NullValueHandling.Ignore)]
        public string[] AdditionalRoles { get; set; }
    }

    public enum FolderColorRgb { The8F8F8F };

    public enum ItemKind { DriveFile };

    public enum LastModifyingUserKind { DriveUser };

    public enum ParentKind { DriveParentReference };

    public enum Domain { GmailCom, LpnuUa };

    public enum PermissionKind { DrivePermission };

    public enum Role { Owner, Reader, Writer };

    public enum TypeEnum { Anyone, User };

    public enum Space { Drive };

    public enum Id { Me };

    public partial class Deserialize
    {
        public static Deserialize FromJson(string json) => JsonConvert.DeserializeObject<Deserialize>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Deserialize self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                FolderColorRgbConverter.Singleton,
                ItemKindConverter.Singleton,
                LastModifyingUserKindConverter.Singleton,
                ParentKindConverter.Singleton,
                DomainConverter.Singleton,
                PermissionKindConverter.Singleton,
                RoleConverter.Singleton,
                TypeEnumConverter.Singleton,
                SpaceConverter.Singleton,
                IdConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class FolderColorRgbConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FolderColorRgb) || t == typeof(FolderColorRgb?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "#8f8f8f")
            {
                return FolderColorRgb.The8F8F8F;
            }
            throw new Exception("Cannot unmarshal type FolderColorRgb");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FolderColorRgb)untypedValue;
            if (value == FolderColorRgb.The8F8F8F)
            {
                serializer.Serialize(writer, "#8f8f8f");
                return;
            }
            throw new Exception("Cannot marshal type FolderColorRgb");
        }

        public static readonly FolderColorRgbConverter Singleton = new FolderColorRgbConverter();
    }

    internal class ItemKindConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ItemKind) || t == typeof(ItemKind?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "drive#file")
            {
                return ItemKind.DriveFile;
            }
            throw new Exception("Cannot unmarshal type ItemKind");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ItemKind)untypedValue;
            if (value == ItemKind.DriveFile)
            {
                serializer.Serialize(writer, "drive#file");
                return;
            }
            throw new Exception("Cannot marshal type ItemKind");
        }

        public static readonly ItemKindConverter Singleton = new ItemKindConverter();
    }

    internal class LastModifyingUserKindConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LastModifyingUserKind) || t == typeof(LastModifyingUserKind?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "drive#user")
            {
                return LastModifyingUserKind.DriveUser;
            }
            throw new Exception("Cannot unmarshal type LastModifyingUserKind");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LastModifyingUserKind)untypedValue;
            if (value == LastModifyingUserKind.DriveUser)
            {
                serializer.Serialize(writer, "drive#user");
                return;
            }
            throw new Exception("Cannot marshal type LastModifyingUserKind");
        }

        public static readonly LastModifyingUserKindConverter Singleton = new LastModifyingUserKindConverter();
    }

    internal class ParentKindConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ParentKind) || t == typeof(ParentKind?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "drive#parentReference")
            {
                return ParentKind.DriveParentReference;
            }
            throw new Exception("Cannot unmarshal type ParentKind");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ParentKind)untypedValue;
            if (value == ParentKind.DriveParentReference)
            {
                serializer.Serialize(writer, "drive#parentReference");
                return;
            }
            throw new Exception("Cannot marshal type ParentKind");
        }

        public static readonly ParentKindConverter Singleton = new ParentKindConverter();
    }

    internal class DomainConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Domain) || t == typeof(Domain?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "gmail.com":
                    return Domain.GmailCom;
                case "lpnu.ua":
                    return Domain.LpnuUa;
            }
            throw new Exception("Cannot unmarshal type Domain");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Domain)untypedValue;
            switch (value)
            {
                case Domain.GmailCom:
                    serializer.Serialize(writer, "gmail.com");
                    return;
                case Domain.LpnuUa:
                    serializer.Serialize(writer, "lpnu.ua");
                    return;
            }
            throw new Exception("Cannot marshal type Domain");
        }

        public static readonly DomainConverter Singleton = new DomainConverter();
    }

    internal class PermissionKindConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PermissionKind) || t == typeof(PermissionKind?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "drive#permission")
            {
                return PermissionKind.DrivePermission;
            }
            throw new Exception("Cannot unmarshal type PermissionKind");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PermissionKind)untypedValue;
            if (value == PermissionKind.DrivePermission)
            {
                serializer.Serialize(writer, "drive#permission");
                return;
            }
            throw new Exception("Cannot marshal type PermissionKind");
        }

        public static readonly PermissionKindConverter Singleton = new PermissionKindConverter();
    }

    internal class RoleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Role) || t == typeof(Role?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "owner":
                    return Role.Owner;
                case "reader":
                    return Role.Reader;
                case "writer":
                    return Role.Writer;
            }
            throw new Exception("Cannot unmarshal type Role");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Role)untypedValue;
            switch (value)
            {
                case Role.Owner:
                    serializer.Serialize(writer, "owner");
                    return;
                case Role.Reader:
                    serializer.Serialize(writer, "reader");
                    return;
                case Role.Writer:
                    serializer.Serialize(writer, "writer");
                    return;
            }
            throw new Exception("Cannot marshal type Role");
        }

        public static readonly RoleConverter Singleton = new RoleConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "anyone":
                    return TypeEnum.Anyone;
                case "user":
                    return TypeEnum.User;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Anyone:
                    serializer.Serialize(writer, "anyone");
                    return;
                case TypeEnum.User:
                    serializer.Serialize(writer, "user");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class SpaceConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Space) || t == typeof(Space?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "drive")
            {
                return Space.Drive;
            }
            throw new Exception("Cannot unmarshal type Space");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Space)untypedValue;
            if (value == Space.Drive)
            {
                serializer.Serialize(writer, "drive");
                return;
            }
            throw new Exception("Cannot marshal type Space");
        }

        public static readonly SpaceConverter Singleton = new SpaceConverter();
    }

    internal class IdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Id) || t == typeof(Id?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "me")
            {
                return Id.Me;
            }
            throw new Exception("Cannot unmarshal type Id");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Id)untypedValue;
            if (value == Id.Me)
            {
                serializer.Serialize(writer, "me");
                return;
            }
            throw new Exception("Cannot marshal type Id");
        }

        public static readonly IdConverter Singleton = new IdConverter();
    }
}